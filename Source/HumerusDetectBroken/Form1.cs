using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Diagnostics;
using LCM;
using LCMTypes;

namespace HumerusDetectBroken
{
    public partial class Form1 : Form
    {
        public static object LockingVar = new object();
        public static string InputFileName = "";

        Boolean blnFirstTimeInResizeEvent = true;
        int intOrigFormWidth = 0;
        int intOrigFormHeight = 0;
        int intOrigImageBoxWidth = 0;
        int intOrigImageBoxHeight = 0;

        Image<Bgr, Byte> imgOriginal;
        Image<Gray, Byte> imgGray;
        Image<Bgr, Byte> imgBlank;

        MCvAvgComp[] acHumerus;
        MCvAvgComp[] acHumerus1;

        HaarCascade hcHumerus;

        BitAnalysis_Sequntials BitAnalysis = new BitAnalysis_Sequntials();
        BitAnalysis_Parallism BitAnalysis_P = new BitAnalysis_Parallism();

        bool Flag = false;

        public Form1()
        {
            InitializeComponent();
            intOrigFormWidth = this.Width;
            intOrigFormHeight = this.Height;
            intOrigImageBoxWidth = ibImage.Width;
            intOrigImageBoxHeight = ibImage.Height;

        }
        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            if (blnFirstTimeInResizeEvent == true)
            {
                blnFirstTimeInResizeEvent = false;
            }
            else
            {
                ibImage.Width = this.Width - (intOrigFormWidth - intOrigImageBoxWidth);
                ibImage.Height = this.Height - (intOrigFormHeight - intOrigImageBoxHeight);
            }
        }

        private void Bt_Find_Click(object sender, EventArgs e)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            PB.Visible = true;
            bool Broken = false;
            PB.Value += 10;
            if (txtImageFile.Text != "")
            {
                try
                {
                    PB.Value += 20;
                    Bt_Find.Enabled = false;
                    Broken = LoadAndProcessImage(txtImageFile.Text);
                    Bt_Find.Enabled = true;
                    PB.Value += 20;
                }
                catch (Exception ex)
                {
                    Bt_Find.Enabled = true;
                    MessageBox.Show(ex.Message);
                    PB.Value = 0;
                    PB.Visible = false;

                }
                PB.Value += 10;
                if (Broken)
                {
                    Lb_Broken.ForeColor = Color.Red;
                    Lb_Broken.Text = "Broken";
                }
                else
                {
                    Lb_Broken.ForeColor = Color.Blue;
                    Lb_Broken.Text = "non Broken";
                }


                ibImage.SizeMode = PictureBoxSizeMode.Zoom;
                ibImage.Image = imgOriginal;
                imageBox1.SizeMode = PictureBoxSizeMode.Zoom;
                imgGray = imgGray.AddWeighted(imgGray, 1.0, 0.0, 0.0);
                imgGray = imgGray.ThresholdToZero(new Gray(100));
                imgGray = imgGray.SmoothGaussian(9);
                imgGray = imgGray.Canny(0, 80);
                imageBox1.Image = imgGray;
                Lb_Progress.Text = "Succeed!";
                PB.Value = 0;
                PB.Visible = false;
            }
            else
            {
                MessageBox.Show("Image file name is empty!");
                PB.Value = 0;
                PB.Visible = false;
            }
            stopwatch.Stop();
            Lb_Time.Text = stopwatch.ElapsedMilliseconds.ToString() + "  milliseconds";
           
        }
        private void Bt_OpenPicture_Click(object sender, EventArgs e)
        {
            PB.Style = ProgressBarStyle.Continuous;
            PB.Maximum = 100;
            PB.Value = 0;
            Lb_Time.Text = "";
            DialogResult drImageFile;
            drImageFile = ofPiture.ShowDialog();
            PB.Value += 5;
            Lb_Progress.Text = "Openning picture...";
            if (drImageFile == System.Windows.Forms.DialogResult.OK && ofPiture.FileName != "")
            {
                PB.Value += 80;
                txtImageFile.Text = ofPiture.FileName;
                try
                {
                    imgOriginal = new Image<Bgr, Byte>(txtImageFile.Text);
                   // LCM.LCM.LCM myLCM = new LCM.LCM.LCM();
           
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.ToString()); }

                ibImage.SizeMode = PictureBoxSizeMode.Zoom;
                PB.Value += 15;
                ibImage.Image = imgOriginal;
                imageBox1.Image = imgBlank;
                Lb_Broken.Text = "...";
            }
            PB.Value = 0;
            Lb_Progress.Text = "Picture loaded";
            Lb_Detected_Contours.Text = "0";
        }

        private void CH_Sequence_CheckedChanged(object sender, EventArgs e)
        {
            bool check = CH_Sequence.Checked;
            if (check) CB_Parallel.Checked = false;
            else CB_Parallel.Checked = true;
        }

        private void CB_Parallel_CheckedChanged(object sender, EventArgs e)
        {
            bool check = CB_Parallel.Checked;
            if (check) CH_Sequence.Checked = false;
            else CH_Sequence.Checked = true;
        }
        
        public bool LoadAndProcessImage(string FileName)
        {
            bool Broken = false;
            imgOriginal = new Image<Bgr, Byte>(FileName);
            imgGray = imgOriginal.Convert<Gray, Byte>();
            //BitAnalysis.StartDye(0, 0, imgGray.Height, imgGray.Width, imgGray);

            hcHumerus = new HaarCascade(@"c:\haarHumerus_03112013_4.8_18.xml"); //haarHumerus_03112013_4.8_18
            ibImage.Image = imgBlank;

            acHumerus = hcHumerus.Detect(imgGray,
                        4.8,
                        18,
                        HAAR_DETECTION_TYPE.SCALE_IMAGE,
                        Size.Empty,
                        Size.Empty);
            acHumerus1 = hcHumerus.Detect(imgGray,
                                        4.8,
                                        18,
                                        HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                        Size.Empty,
                                        Size.Empty);


            int count1 = 0, count2 = 0;
            PB.Value += 10;
            foreach (MCvAvgComp acHum in acHumerus)
            {
                if (GetCoordination(acHum))  // to get coordination x,y, and with, high
                {
                    imgOriginal.Draw(acHum.rect, new Bgr(Color.Blue), 2);
                    count1++;
                    Broken = true;
                }
                imgGray.Draw(acHum.rect, new Gray(0.0), 1);
            }
            PB.Value += 10;
            if (count1 == 0)
            {
                foreach (MCvAvgComp acHum1 in acHumerus1)
                {
                    if (GetCoordination(acHum1))  // to get coordination x,y, and with, high
                    {
                        imgOriginal.Draw(acHum1.rect, new Bgr(Color.Red), 2);
                        count2++;
                        Broken = true;
                    }
                    imgGray.Draw(acHum1.rect, new Gray(0.0), 1);
                }
            }
            if (count1 == 0  && count2 == 0 )
            {
                imgGray = imgGray.AddWeighted(imgGray, 1.0, 0.0, 0.0);
                imgGray = imgGray.ThresholdToZero(new Gray(100));
                imgGray = imgGray.SmoothGaussian(9);
                imgGray = imgGray.Canny(0, 80);

                hcHumerus = new HaarCascade(@"c:\HaarHumerus_03172013_2.8_3.xml");

                acHumerus = hcHumerus.Detect(imgGray,
                   2.8,
                   3,
                    HAAR_DETECTION_TYPE.SCALE_IMAGE,
                    Size.Empty,
                    Size.Empty);
                acHumerus1 = hcHumerus.Detect(imgGray,
                    2.8,
                    3,
                    HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    Size.Empty,
                    Size.Empty);
                foreach (MCvAvgComp acHum in acHumerus)
                {
                    if (GetCoordination(acHum))  // to get coordination x,y, and with, high
                    {
                        imgOriginal.Draw(acHum.rect, new Bgr(Color.Orange), 2);
                        Broken = true;
                    }
                    imgGray.Draw(acHum.rect, new Gray(0.0), 1);
                }
                foreach (MCvAvgComp acHum1 in acHumerus1)
                {

                    if (GetCoordination(acHum1))  // to get coordination x,y, and with, high
                    {
                        imgOriginal.Draw(acHum1.rect, new Bgr(Color.Green), 2);
                        Broken = true;
                    }
                    imgGray.Draw(acHum1.rect, new Gray(), 1);
                }


            }
            PB.Value = +20;

            return Broken;
        }
        private bool GetCoordination(MCvAvgComp acHum)
        {

            if (!CB_Parallel.Checked)
            {
                return BitAnalysis.StartDye(acHum.rect.X, acHum.rect.Y, acHum.rect.Width, acHum.rect.Height, imgGray); // Analyze in Haar detection
            }
            else
            {
                return BitAnalysis_P.StartDye(acHum.rect.X, acHum.rect.Y, acHum.rect.Width, acHum.rect.Height, imgGray);
            }
            
        }

        internal class SimpleSubscriber : LCM.LCM.LCMSubscriber
        {
            public void MessageReceived(LCM.LCM.LCM lcm, string channel, LCM.LCM.LCMDataInputStream dins)
            {
                // 2. Ignore ENHANCED Channel message
                if (channel == "PROCESS")
                {
                    imageReady_t listen = new imageReady_t(dins);

                    //                    MessageBox.Show(listen.imageFilename);
                    lock (LockingVar)
                    {
                        // 2. pass filename, get JointX, JointY, Radius
                        //MainForm.ProcSubmit(listen.imageFilename);
                        // Publish <cx, cy, r>
                        InputFileName = listen.imageFilename;
                    }
                }
            }
        }
    }

}
