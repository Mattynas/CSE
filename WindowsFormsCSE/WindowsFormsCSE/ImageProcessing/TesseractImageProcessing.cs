using System.Drawing;
using Tesseract;
using Emgu.CV;
using Emgu.CV.Structure;
using ImageMagick;
//using System.Windows.Forms;

namespace WindowsFormsCSE
{
    class TesseractImageProcessing : IImageTextProcessing, IImagePreProcess<Bitmap>
    {
        private string processedText;
        private Image<Bgr, byte> inputImage;
        private Bitmap processedImage;
        private int blockSize;
        private double param1;

        public TesseractImageProcessing(string fileName, int blockSize, double param1)
        {
            this.param1 = param1;
            this.blockSize = blockSize;
            ImageTextAnalysis(fileName);
        }

        public Bitmap GetProcessedImage { get { return this.processedImage; } }

        public string GetProcessedText { get { return this.processedText; } }

        public void ImageTextAnalysis(string imageName)
        {
            inputImage = new Image<Bgr, byte>(imageName);
            BinarizeImage(inputImage.ToBitmap());

            var ocr = new TesseractEngine(@"../../tessdata", "lit", EngineMode.Default);
            var page = ocr.Process(processedImage);

            processedText = page.GetText();

        }

        public void BinarizeImage(Bitmap image)
        {
            Image<Gray, byte> imgGray;
            Image<Gray, byte> imgBinarized;

            imgGray = new Image<Gray, byte>(image);

            imgBinarized = new Image<Gray, byte>(imgGray.Width, imgGray.Height, new Gray(0));
            

            //double thrshValue = CvInvoke.Threshold(imgGray, imgBinarized, 0, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);

            CvInvoke.AdaptiveThreshold(imgGray, imgBinarized, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC, Emgu.CV.CvEnum.ThresholdType.Binary, blockSize, param1);
            //MessageBox.Show(thrshValue.ToString()); display threshold value for testing purposes

            processedImage = imgBinarized.ToBitmap();

        }
    }
}
