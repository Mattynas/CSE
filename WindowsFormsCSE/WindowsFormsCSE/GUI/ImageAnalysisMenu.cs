using System;
using System.Data;
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
        private Rectangle mRect;
        public ImageAnalysisMenu()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageFile = openFileDialog.FileName;

                pictureBox1.Image = new Bitmap(imageFile);

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                System.IO.File.WriteAllText(openFileDialog.FileName, textBox1.Text);
        }

        private void tesseractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var imageProcessing = new TesseractImageProcessing(imageFile);

            pictureBox2.Image = imageProcessing.GetProcessedImage;

            textBox1.Text = imageProcessing.GetProcessedText;

            var receipt = new Receipt(imageProcessing.GetProcessedText);

        }

        private void ironOCRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var imageProcessing = new IronOCRImageProcessing(imageFile, mRect);

            pictureBox2.Image = imageProcessing.GetProcessedImage;

            textBox1.Text = imageProcessing.GetProcessedText;

            var receipt = new Receipt(imageProcessing.GetProcessedText);
        }
    }
}
