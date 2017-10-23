using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using IronOcr;

namespace WindowsFormsCSE.ImageProcessing
{
    class IronOCRImageProcessing : IImageProcess
    {
        private string processedText;
        private Bitmap inputImage;
        private Bitmap processedImage;

        public string GetProcessedText { get { return this.processedText; } }

        public Bitmap GetProcessedImage { get { return this.processedImage; } }

        public IronOCRImageProcessing(string fileName)
        {
            ImageTextAnalysis(fileName);
        }
        public IronOCRImageProcessing(Bitmap pic)
        {
            this.inputImage = pic;
            ImageTextAnalysis(pic);
        }

        public void ImageTextAnalysis(string imageName)
        {
            var ocr = new AutoOcr();

            Bitmap inputImage = new Bitmap(@imageName);

            BinarizeImage(inputImage);

            var Results = ocr.Read(processedImage);

            processedText = Results.Text;

        }
        public void ImageTextAnalysis(Bitmap img)
        {
            var ocr = new AutoOcr();

            BinarizeImage(img);

            var Results = ocr.Read(processedImage);

            processedText = Results.Text;

        }

        public void BinarizeImage(Bitmap image)
        {
            Image<Gray, byte> imgGray;
            Image<Gray, byte> imgBinarized;

            imgGray = new Image<Gray, byte>(image);

            imgBinarized = new Image<Gray, byte>(imgGray.Width, imgGray.Height, new Gray(0));

            double thrshValue = CvInvoke.Threshold(imgGray, imgBinarized, 0, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);

            processedImage = imgBinarized.ToBitmap();
        }
    }
}
