using System;
using System.Drawing;
using System.Windows.Forms;

namespace CameraApp
{
    public partial class MainForm : Form
    {
        private Webcam webcam;

        public MainForm()
        {
            InitializeComponent();
            webcam = new Webcam();
            webcam.OnFrameReady += Webcam_OnFrameReady;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            webcam.Dispose();
        }

        private void Webcam_OnFrameReady(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)sender;
            pictureBox.Image = bmp;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            webcam.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            webcam.Stop();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            Bitmap bmp = webcam.Capture();
            bmp.Save("image.jpg");
            pictureBox.Image = bmp;
        }
    }
}
