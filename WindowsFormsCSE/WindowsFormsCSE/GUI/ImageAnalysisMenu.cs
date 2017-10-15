using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsCSE.Model;

namespace WindowsFormsCSE.GUI
{
    public partial class ImageAnalysisMenu : Form
    {
        public ImageAnalysisMenu()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var imageProcessing = new TesseractImageProcessing(openFileDialog.FileName);

                pictureBox1.Image = new Bitmap(openFileDialog.FileName);

                pictureBox2.Image = imageProcessing.GetProcessedImage;

                textBox1.Text = imageProcessing.GetProcessedText;

                var receipt = new Receipt(imageProcessing.GetProcessedText);


            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"../../ImageTextFile.txt", textBox1.Text);
        }
    }
}
