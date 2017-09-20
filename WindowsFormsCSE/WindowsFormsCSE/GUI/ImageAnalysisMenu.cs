using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WindowsFormsCSE.GUI
{
    public partial class ImageAnalysisMenu : Form
    {
        Page page;
        public ImageAnalysisMenu()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image<Bgr, byte> imgInput;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imgInput = new Image<Bgr, byte>(openFileDialog.FileName);
                pictureBox1.Image = imgInput.Bitmap;

                var imgBin = ImageProcessing.ImageBinarization(imgInput);
                pictureBox2.Image = imgBin.Bitmap;

                page = ImageProcessing.AnalyseImageText(imgBin.Bitmap);

                textBox1.Text = page.GetText();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"../../ImageTextFile.txt", page.GetText());
        }
    }
}
