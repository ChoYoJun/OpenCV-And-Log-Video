namespace OpenCV
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_OpenCamera = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CameraWorker = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_OpenCamera
            // 
            this.bt_OpenCamera.Location = new System.Drawing.Point(30, 30);
            this.bt_OpenCamera.Name = "bt_OpenCamera";
            this.bt_OpenCamera.Size = new System.Drawing.Size(144, 30);
            this.bt_OpenCamera.TabIndex = 0;
            this.bt_OpenCamera.Text = "Open Camera";
            this.bt_OpenCamera.UseVisualStyleBackColor = true;
            this.bt_OpenCamera.Visible = false;
            this.bt_OpenCamera.Click += new System.EventHandler(this.bt_OpenCamera_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(30, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(428, 170);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // CameraWorker
            // 
            this.CameraWorker.WorkerReportsProgress = true;
            this.CameraWorker.WorkerSupportsCancellation = true;
            this.CameraWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CameraWorker_DoWork);
            this.CameraWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.CameraWorker_ProgressChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Record";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(322, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 30);
            this.button2.TabIndex = 3;
            this.button2.Text = "Stop Record";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(30, 294);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(99, 37);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 342);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bt_OpenCamera);
            this.Enabled = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button bt_OpenCamera;
        private PictureBox pictureBox1;
        public System.ComponentModel.BackgroundWorker CameraWorker;
        private Button button1;
        private Button button2;
        private Panel panel1;
    }
}