using System;
using System.Drawing;
using System.Windows.Forms;
using shopGuru;
using shopGuru.ImageProcessing;
using shopGuru.Model;
using shopGuru.Properties;
using shopGuru.Validation;

namespace WindowsFormsCSE.GUI
{
    public partial class ImageAnalysisMenu : Form
    {
        private string imageFile;
        private Bitmap loadedImage;

        private ImageCroping imgCrop;
        private Receipt receipt;

        private LoginForm loginform;

        private IImageProcess imageProcessing;

        public ImageAnalysisMenu(LoginForm login)
        {
            InitializeComponent();
            loginform = login;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageFile = openFileDialog.FileName;

                loadedImage = new Bitmap(imageFile);
                pictureBox1.Image = loadedImage;
                toolStripStatusLabel1.Text = Resources.IMAGEPROCESSING_helpText1;
                imgCrop = new ImageCroping();
            }
           
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                IOManager.SaveProcessedText(saveFileDialog1.FileName, textBox1.Text);
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                imgCrop.SetRectStartPoint(e);
               Invalidate();
            }
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
            if (pictureBox1.Image != null)
            {
                imgCrop.DefineROI();
                pictureBox2.Image = imgCrop.GetCropedImage;
                toolStripStatusLabel1.Text = Resources.IMAGEPROCESSING_helpText2;
            }
        }

        private void PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                imgCrop.SetNewRectangle();
                ((PictureBox)sender).Invalidate();
            }
        }

        private void CroppedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageProcessing = new TesseractImageProcessing(imgCrop.GetCropedImage);
            UpdateForms();
        }

        private void FullImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageProcessing = new TesseractImageProcessing(imageFile);
            UpdateForms();
        }

        private void FullImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            imageProcessing = new IronOCRImageProcessing(imageFile);
            UpdateForms();
        }

        private void CroppedImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            imageProcessing = new IronOCRImageProcessing(imgCrop.GetCropedImage);
            UpdateForms();
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

        private void AnalyseTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            receipt = new Receipt(textBox1.Text);
        }

        private void printItemListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(receipt != null)
            {
                textBox1.Text = receipt.GetItemList();
            }
            else
            {
                MessageBox.Show(Resources.ERROR_wentWrong + "\n\rNo Receipt found, try analyzing the text first");
            }
        }

        private void ImageAnalysisMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginform.Close();
        }
        private void UpdateForms()
        {
            pictureBox2.Image = imageProcessing.GetProcessedImage;
            textBox1.Text = imageProcessing.GetProcessedText;

            toolStripStatusLabel1.Text = Resources.IMAGEPROCESSING_helpText3;
        }
    }
}
