using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsCSE.ImageProcessing;
using WindowsFormsCSE.Model;
using WindowsFormsCSE.Properties;

namespace WindowsFormsCSE.GUI
{
    public partial class ImageAnalysisMenu : Form
    {
        private string imageFile;
        private Bitmap loadedImage;

        private ImageCroping imgCrop = new ImageCroping();

        public ImageAnalysisMenu()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageFile = openFileDialog.FileName;

                loadedImage = new Bitmap(imageFile);
                pictureBox1.Image = loadedImage;
                toolStripStatusLabel1.Text = Resources.IMAGEPROCESSING_helpText1;

            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                System.IO.File.WriteAllText(openFileDialog.FileName, textBox1.Text);
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            imgCrop.SetRectStartPoint(e);
            Invalidate();
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                imgCrop.DrawROI(imageFile, pictureBox1, e);
                ((PictureBox)sender).Invalidate();
            }
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                imgCrop.SelectROI(sender, e);
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            imgCrop.DefineROI();
            pictureBox2.Image = imgCrop.GetCropedImage;
            toolStripStatusLabel1.Text = Resources.IMAGEPROCESSING_helpText2;
        }

        private void PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            imgCrop.SetNewRectangle();
            ((PictureBox)sender).Invalidate();
        }

        private void CroppedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var imageProcessing = new TesseractImageProcessing(imgCrop.GetCropedImage);

            pictureBox2.Image = imageProcessing.GetProcessedImage;

            textBox1.Text = imageProcessing.GetProcessedText;

            var receipt = new Receipt(imageProcessing.GetProcessedText);
        }

        private void FullImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var imageProcessing = new TesseractImageProcessing(imageFile);

            pictureBox2.Image = imageProcessing.GetProcessedImage;

            textBox1.Text = imageProcessing.GetProcessedText;

            var receipt = new Receipt(imageProcessing.GetProcessedText);
        }

        private void FullImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var imageProcessing = new IronOCRImageProcessing(imageFile);

            pictureBox2.Image = imageProcessing.GetProcessedImage;

            textBox1.Text = imageProcessing.GetProcessedText;

            var receipt = new Receipt(imageProcessing.GetProcessedText);
        }

        private void CroppedImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var imageProcessing = new IronOCRImageProcessing(imgCrop.GetCropedImage);

            pictureBox2.Image = imageProcessing.GetProcessedImage;

            textBox1.Text = imageProcessing.GetProcessedText;

            var receipt = new Receipt(imageProcessing.GetProcessedText);
        }

        private void rotateImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                loadedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                loadedImage.Save(imageFile);
                loadedImage = new Bitmap(imageFile);
                pictureBox1.Image = loadedImage;
            }
        }
    }
}
