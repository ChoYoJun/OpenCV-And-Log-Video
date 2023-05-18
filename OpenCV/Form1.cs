using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;

namespace OpenCV
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll ", EntryPoint = "SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll ", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);

        public Form1()
        {
            InitializeComponent();
        }
        public VideoCapture capture = new VideoCapture();//ʵ����һ��capture
        public VideoWriter videoWriter = new VideoWriter();
        public Mat mat = new Mat();
        public bool FlagCloseForm = false;
        private void openCamera()
        {

            capture.Open(0, VideoCaptureAPIs.ANY);
            if (!capture.IsOpened())
            {
                Close();
                MessageBox.Show("open camera failed.");
                return;
            }
            bt_OpenCamera.Text = "close Camera.";
            CameraWorker.RunWorkerAsync();
        }

        private void closeCamera()
        {
            bt_OpenCamera.Text = "open Camera.";
            CameraWorker.CancelAsync();
            capture.Release();
            pictureBox1.Image = null;
        }

        private void CameraWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var bgWorker = (BackgroundWorker)sender;
            while (!bgWorker.CancellationPending)
            {
                using (var frameMat = capture.RetrieveMat())
                {
                    var frameBitmap = BitmapConverter.ToBitmap(frameMat);
                    bgWorker.ReportProgress(0, frameBitmap);
                }
                Thread.Sleep(100);
            }
        }

        private void CameraWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Bitmap frameBitmap = (Bitmap)e.UserState;
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = frameBitmap;
        }

        private void RecordVideo()
        {
            while (capture.IsOpened())
            {
                if (capture.Read(mat) && !FlagCloseForm)
                {
                    videoWriter.Write(mat);//д����Ƶ
                                           //                   Window.ShowImages(mat);
                    var key = Cv2.WaitKey(1);
                    if (key == 27)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public String LogVideo()
        { 
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string logFilePath = "Log\\"+ currentTime.Year.ToString()+"-"+currentTime.Month.ToString() + "-"+currentTime.Day.ToString() + "    " + currentTime.Hour.ToString() + "-" + currentTime.Minute.ToString() + "-" + currentTime.Second.ToString() + @".avi";
            return logFilePath;
        }

        private void bt_OpenCamera_Click(object sender, EventArgs e)
        {
            if (CameraWorker.IsBusy)
            {
                closeCamera();
            }
            else
            {
                openCamera();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(RecordVideo);
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            videoWriter.Release();
            mat.Release();
            Cv2.DestroyAllWindows();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VideoWriter videoWriterInit = new VideoWriter(LogVideo(), VideoWriter.FourCC(@"XVID"), 20, new OpenCvSharp.Size(640, 480));
            videoWriter = videoWriterInit;
            if (CameraWorker.IsBusy)
            {
                closeCamera();
            }
            else
            {
                openCamera();
            }
            Thread thread = new Thread(RecordVideo);
            thread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FlagCloseForm = true;
            Thread.Sleep(100);
            videoWriter.Release();
            mat.Release();
            Cv2.DestroyAllWindows();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Process cmdP = new Process();
            cmdP.StartInfo.FileName = "C:\\Program Files (x86)\\Tencent\\WeChat\\WeChat.exe";
            cmdP.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
            cmdP.Start();
            Thread.Sleep(200);
            SetWindowPos(cmdP.MainWindowHandle, IntPtr.Zero, this.panel1.Location.X, this.panel1.Location.Y, panel1.Width, panel1.Height, 0);
            SetParent(cmdP.MainWindowHandle, panel1.Handle);
            ShowWindow(cmdP.MainWindowHandle, 3);
            //������С����ʾ
            this.WindowState = FormWindowState.Minimized;
            //����ʾ����������
            this.ShowInTaskbar = false;
        }
    }
}