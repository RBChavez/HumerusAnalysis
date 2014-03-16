namespace HumerusDetectBroken
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ibImage = new Emgu.CV.UI.ImageBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImageFile = new System.Windows.Forms.TextBox();
            this.ofHarrHumerus = new System.Windows.Forms.OpenFileDialog();
            this.ofPiture = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.Lb_Detected_Contours = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Lb_Broken = new System.Windows.Forms.Label();
            this.Lb_Progress = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Lb_TakeTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Bt_Find = new System.Windows.Forms.Button();
            this.Bt_OpenPicture = new System.Windows.Forms.Button();
            this.PB = new System.Windows.Forms.ProgressBar();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CH_Sequence = new System.Windows.Forms.CheckBox();
            this.CB_Parallel = new System.Windows.Forms.CheckBox();
            this.Lb_Time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ibImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ibImage
            // 
            this.ibImage.Location = new System.Drawing.Point(21, 19);
            this.ibImage.Name = "ibImage";
            this.ibImage.Size = new System.Drawing.Size(363, 427);
            this.ibImage.TabIndex = 2;
            this.ibImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "picture file";
            // 
            // txtImageFile
            // 
            this.txtImageFile.Enabled = false;
            this.txtImageFile.Location = new System.Drawing.Point(70, 12);
            this.txtImageFile.Name = "txtImageFile";
            this.txtImageFile.Size = new System.Drawing.Size(677, 20);
            this.txtImageFile.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Detected : ";
            // 
            // Lb_Detected_Contours
            // 
            this.Lb_Detected_Contours.AutoSize = true;
            this.Lb_Detected_Contours.Location = new System.Drawing.Point(75, 51);
            this.Lb_Detected_Contours.Name = "Lb_Detected_Contours";
            this.Lb_Detected_Contours.Size = new System.Drawing.Size(13, 13);
            this.Lb_Detected_Contours.TabIndex = 9;
            this.Lb_Detected_Contours.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Lb_Time);
            this.groupBox2.Controls.Add(this.Lb_Broken);
            this.groupBox2.Controls.Add(this.Lb_Progress);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.Lb_TakeTime);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Lb_Detected_Contours);
            this.groupBox2.Location = new System.Drawing.Point(755, 311);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 159);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // Lb_Broken
            // 
            this.Lb_Broken.AutoSize = true;
            this.Lb_Broken.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Broken.Location = new System.Drawing.Point(17, 95);
            this.Lb_Broken.Name = "Lb_Broken";
            this.Lb_Broken.Size = new System.Drawing.Size(30, 26);
            this.Lb_Broken.TabIndex = 25;
            this.Lb_Broken.Text = "...";
            // 
            // Lb_Progress
            // 
            this.Lb_Progress.AutoSize = true;
            this.Lb_Progress.Location = new System.Drawing.Point(75, 28);
            this.Lb_Progress.Name = "Lb_Progress";
            this.Lb_Progress.Size = new System.Drawing.Size(16, 13);
            this.Lb_Progress.TabIndex = 14;
            this.Lb_Progress.Text = "...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Progress :";
            // 
            // Lb_TakeTime
            // 
            this.Lb_TakeTime.AutoSize = true;
            this.Lb_TakeTime.Location = new System.Drawing.Point(89, 64);
            this.Lb_TakeTime.Name = "Lb_TakeTime";
            this.Lb_TakeTime.Size = new System.Drawing.Size(0, 13);
            this.Lb_TakeTime.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Take time : ";
            // 
            // Bt_Find
            // 
            this.Bt_Find.Location = new System.Drawing.Point(755, 152);
            this.Bt_Find.Name = "Bt_Find";
            this.Bt_Find.Size = new System.Drawing.Size(192, 71);
            this.Bt_Find.TabIndex = 11;
            this.Bt_Find.Text = "Analyze";
            this.Bt_Find.UseVisualStyleBackColor = true;
            this.Bt_Find.Click += new System.EventHandler(this.Bt_Find_Click);
            // 
            // Bt_OpenPicture
            // 
            this.Bt_OpenPicture.Location = new System.Drawing.Point(755, 12);
            this.Bt_OpenPicture.Name = "Bt_OpenPicture";
            this.Bt_OpenPicture.Size = new System.Drawing.Size(30, 19);
            this.Bt_OpenPicture.TabIndex = 19;
            this.Bt_OpenPicture.Text = "...";
            this.Bt_OpenPicture.UseVisualStyleBackColor = true;
            this.Bt_OpenPicture.Click += new System.EventHandler(this.Bt_OpenPicture_Click);
            // 
            // PB
            // 
            this.PB.Location = new System.Drawing.Point(249, 201);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(258, 10);
            this.PB.TabIndex = 23;
            this.PB.Visible = false;
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(390, 19);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(330, 427);
            this.imageBox1.TabIndex = 24;
            this.imageBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PB);
            this.groupBox1.Controls.Add(this.ibImage);
            this.groupBox1.Controls.Add(this.imageBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 462);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CH_Sequence);
            this.groupBox3.Controls.Add(this.CB_Parallel);
            this.groupBox3.Location = new System.Drawing.Point(753, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 94);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Setting";
            // 
            // CH_Sequence
            // 
            this.CH_Sequence.AutoSize = true;
            this.CH_Sequence.Checked = true;
            this.CH_Sequence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CH_Sequence.Location = new System.Drawing.Point(24, 30);
            this.CH_Sequence.Name = "CH_Sequence";
            this.CH_Sequence.Size = new System.Drawing.Size(129, 17);
            this.CH_Sequence.TabIndex = 1;
            this.CH_Sequence.Text = "Sequential Computing";
            this.CH_Sequence.UseVisualStyleBackColor = true;
            this.CH_Sequence.CheckedChanged += new System.EventHandler(this.CH_Sequence_CheckedChanged);
            // 
            // CB_Parallel
            // 
            this.CB_Parallel.AutoSize = true;
            this.CB_Parallel.Location = new System.Drawing.Point(24, 62);
            this.CB_Parallel.Name = "CB_Parallel";
            this.CB_Parallel.Size = new System.Drawing.Size(113, 17);
            this.CB_Parallel.TabIndex = 0;
            this.CB_Parallel.Text = "Parallel Computing";
            this.CB_Parallel.UseVisualStyleBackColor = true;
            this.CB_Parallel.CheckedChanged += new System.EventHandler(this.CB_Parallel_CheckedChanged);
            // 
            // Lb_Time
            // 
            this.Lb_Time.AutoSize = true;
            this.Lb_Time.Location = new System.Drawing.Point(75, 82);
            this.Lb_Time.Name = "Lb_Time";
            this.Lb_Time.Size = new System.Drawing.Size(13, 13);
            this.Lb_Time.TabIndex = 26;
            this.Lb_Time.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(956, 505);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Bt_OpenPicture);
            this.Controls.Add(this.Bt_Find);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtImageFile);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Humerus Analysis";
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            ((System.ComponentModel.ISupportInitialize)(this.ibImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImageFile;
        private System.Windows.Forms.OpenFileDialog ofHarrHumerus;
        private System.Windows.Forms.OpenFileDialog ofPiture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lb_Detected_Contours;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Bt_Find;
        private System.Windows.Forms.Button Bt_OpenPicture;
        private System.Windows.Forms.Label Lb_TakeTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar PB;
        private System.Windows.Forms.Label Lb_Progress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Lb_Broken;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox CH_Sequence;
        private System.Windows.Forms.CheckBox CB_Parallel;
        private System.Windows.Forms.Label Lb_Time;
    }
}

