using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsCSE.Model;
using WindowsFormsCSE.Properties;

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
                try
                {
                    int blockSize = Convert.ToInt32(blockSizeTextBox.Text);
                    double param1 = Convert.ToDouble(param1TextBox.Text);

                    var imageProcessing = new TesseractImageProcessing(openFileDialog.FileName, blockSize, param1);

                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);

                    pictureBox2.Image = imageProcessing.GetProcessedImage;

                    textBox1.Text = imageProcessing.GetProcessedText;

                    var receipt = new Receipt(imageProcessing.GetProcessedText);
                }
                catch(FormatException ex)
                {
                    MessageBox.Show(ex.ToString());
                } 
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(Resources.IMAGEANALYSIS_PATH_imageText, textBox1.Text);
        }
    }
}
