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

namespace HumerusDetectBroken
{
    class BitAnalysis_Sequntials
    {
        /// <summary>
        /// Get image convert to bitmap and scan pixel by pixel
        /// and draw the possible bone estimate sum of white color should be
        /// and count it for real
        /// make the + and - value
        /// compare with estimate value with the real one
        /// sent data if it exceed more then the estimate should draw the rectangle
        /// and report it is broken
        /// if not shuold not draw anything 
        /// </summary>
        /// <param name="imgGray"></param>
        ///
        bool Flag = false; // true = broken, false = non broken
        Image<Gray, Byte> imgGray;
        int heigh = 0;
        int width = 0;
        int Start_Pixel_x = 0;
        int Start_Pixel_y = 0;
        Bitmap bitmap;
        int count_pixel = 0; // count for max pixel = heigh
        Color Vector_Color = Color.LightYellow;
       

        public bool StartDye(int X,int Y,int Heigh,int Width,Image<Gray, Byte> ImgGray)
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
            Initial_Dye_Pixel();

            return Flag;
        }
        public void Initial_Dye_Pixel()
        {
            count_pixel = 0;
            int a = 0;
            int b = 0;
            // college data in array        
            for (int i = 0; i < width; i++) // row
            {
                // ArrayList Set_Pixel_In_Collumn = new ArrayList();
                for (int j = 0; j < heigh; j++)  // collumn
                {
                    a = j + Start_Pixel_x;
                    b = i + Start_Pixel_y;
                    Color pixel = bitmap.GetPixel(a, b);
                    if (pixel.R == 255 && pixel.G == 255 && pixel.B == 255) //RGB is white then count
                    {
                        count_pixel++;
                        bitmap.SetPixel(a, b, Vector_Color);    // color new vector with Red
                        Find_Boundary_List(a,b); // find boundary area

                    }
                }
                //Set_Pixel_In_Row.Add(Set_Pixel_In_Collumn);
            }
        }
        public void Find_Boundary_List(int x,int y)
        {
            int NewX,NewY;
            if (x == Start_Pixel_x)  //pixel on the left; Check center and right
            {
                NewX = x; //center
                NewY = y+1;
                Create_Vector(NewX, NewY);
                NewX = x + 1; // right
                NewY = y + 1;
                Create_Vector(NewX, NewY);
            }
            else if (x == Start_Pixel_x+ width) // pixel on the right ; check center and left
            {
                NewX = x - 1; //left
                NewY = y + 1;
                Create_Vector(NewX, NewY);
                NewX = x; //center
                NewY = y + 1;
                Create_Vector(NewX, NewY);
            }
            else if (y != Start_Pixel_y+ heigh) // not the last row
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
            Check_Pixel();
            Initial_Dye_Pixel();
        }
        public void Create_Vector(int x,int y)
        {
            Color pixel = bitmap.GetPixel(x,y);
            if (pixel.R == 255 && pixel.G == 255 && pixel.B == 255) //RGB is white then count
            {
                count_pixel++;
                bitmap.SetPixel(x, y, Vector_Color);    // color new vector with Red
                Find_Boundary_List(x, y);
            }
        }

        public void Check_Pixel() //pixel should be closed to heigh
        {
            // sent bound list to find continue untill end of hightest pixels, and color the one that already explored
            
            if (count_pixel < heigh) Flag = true; // minimul slop pixel = heigh
            else Flag = false; // broken
        }
    }
}
 