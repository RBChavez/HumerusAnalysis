using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Drawing;
using System.Collections;
using MPI;
namespace HumerusDetectBroken
{
    class BitAnalysis_Parallism
    {
        bool Flag = false; // true = broken, false = non broken
        Image<Gray, Byte> imgGray;
        int heigh = 0;
        int width = 0;
        int Start_Pixel_x = 0;
        int Start_Pixel_y = 0;
        Bitmap bitmap;
        int count_pixel = 0; // count for max pixel = heigh
        Color Vector_Color = Color.LightYellow;

        int size, rank;
        Intracommunicator comm = Communicator.world;

        public bool StartDye(int X, int Y, int Heigh, int Width, Image<Gray, Byte> ImgGray)
        {
            heigh = Heigh;
            width = Width;
            Start_Pixel_x = X;
            Start_Pixel_y = Y;
            imgGray = ImgGray;

            if (width <= 24) //elliminate noise 67,24
            { return false; }
            //ArrayList Set_Pixel_In_Row = new ArrayList(); // Array for college
            imgGray = imgGray.AddWeighted(imgGray, 1.0, 0.0, 0.0);
            imgGray = imgGray.ThresholdToZero(new Gray(100));
            imgGray = imgGray.SmoothGaussian(9);
            imgGray = imgGray.Canny(0, 80);
            bitmap = new Bitmap(imgGray.ToBitmap());
            Initial_Dye_Pixel(0);

            return Flag;
        }
        // pallalism here////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Initial_Dye_Pixel(int PixelFromEachRank)
        {
            count_pixel = 0;
            int a = 0;
            int b = 0;
            // college data in array        
            for (int i = 0; i < heigh / comm.Size; i++) // row
            {
                // ArrayList Set_Pixel_In_Collumn = new ArrayList();
                for (int j = 0; j < width; j++)  // collumn
                {
                    a = (j + Start_Pixel_x) * comm.Rank + 1;
                    b = (i + Start_Pixel_y) * comm.Rank + 1;
                    Color pixel = bitmap.GetPixel(a, b);
                    if (pixel.R == 255 && pixel.G == 255 && pixel.B == 255) //RGB is white then count
                    {
                        count_pixel++;
                        bitmap.SetPixel(a, b, Vector_Color);    // color new vector with Red
                        Find_Boundary_List(a, b); // find boundary area

                    }
                }
            }
            if (comm.Rank == 0)
            {

            }
        }
        public void Find_Boundary_List(int x, int y)
        {
            int NewX, NewY;
            if (x == Start_Pixel_x)  //pixel on the left; Check center and right
            {
                NewX = x; //center
                NewY = y + 1;
                Create_Vector(NewX, NewY);
                NewX = x + 1; // right
                NewY = y + 1;
                Create_Vector(NewX, NewY);
            }
            else if (x == Start_Pixel_x + width) // pixel on the right ; check center and left
            {
                NewX = x - 1; //left
                NewY = y + 1;
                Create_Vector(NewX, NewY);
                NewX = x; //center
                NewY = y + 1;
                Create_Vector(NewX, NewY);
            }
            else if (y != Start_Pixel_y + heigh) // not the last row
            {
                NewX = x - 1; //left
                NewY = y + 1;
                Create_Vector(NewX, NewY);
                NewX = x; //center
                NewY = y + 1;
                Create_Vector(NewX, NewY);
                NewX = x + 1; // right
                NewY = y + 1;
                Create_Vector(NewX, NewY);
            }
            int PixelFromEachRank = Check_Pixel();
            Initial_Dye_Pixel(PixelFromEachRank);
        }
        public void Create_Vector(int x, int y)
        {
            Color pixel = bitmap.GetPixel(x, y);
            if (pixel.R == 255 && pixel.G == 255 && pixel.B == 255) //RGB is white then count
            {
                count_pixel++;
                bitmap.SetPixel(x, y, Vector_Color);    // color new vector with Red
                Find_Boundary_List(x, y);
            }
        }

        public int Check_Pixel() //pixel should be closed to heigh
        {
            // sent bound list to find continue untill end of hightest pixels, and color the one that already explored
            int PixelFromEachRank = 0;
            if (count_pixel < heigh / comm.Size)
            {
                Flag = true; // minimul slop pixel = heigh
            }
            else
            {
                Flag = false;
            }
            PixelFromEachRank = count_pixel;
            return PixelFromEachRank;
        }
    }
}
