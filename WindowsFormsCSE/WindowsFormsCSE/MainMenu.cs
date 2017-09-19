using System;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;

namespace WindowsFormsCSE
{
    public partial class ImageAnalysisMenu : Form
    {
        public ImageAnalysisMenu()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click_1(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var img = new Bitmap(openFileDialog.FileName);
                var ocr = new TesseractEngine(@"./tessdata","eng",EngineMode.TesseractOnly);
                var page = ocr.Process(img);
                textField.Text = page.GetText();
            }
        }
    }
}
