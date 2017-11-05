using System.Drawing;
using Tesseract;
using Emgu.CV;
using Emgu.CV.Structure;
using shopGuru.Properties;
using shopGuru.ImageProcessing;
//using System.Windows.Forms;

namespace shopGuru
{
    class TesseractImageProcessing : IImageProcess
    {
        private string processedText;
        private Image<Bgr, byte> inputImage;
        private Bitmap processedImage;

        public TesseractImageProcessing(string fileName) => ImageTextAnalysis(fileName);

        public TesseractImageProcessing(Bitmap pic) => ImageTextAnalysis(pic);

        public Bitmap GetProcessedImage { get { return this.processedImage; } }

        public string GetProcessedText { get { return this.processedText; } }

        public void ImageTextAnalysis(string imageName)
        {
            inputImage = new Image<Bgr, byte>(imageName);
            BinarizeImage(inputImage.ToBitmap());
            
            var ocr = new TesseractEngine(Resources.IMAGEPROCESSING_PATH_dataPath, Resources.IMAGEPROCESSING_lang, EngineMode.TesseractOnly);
            var page = ocr.Process(processedImage);

            processedText = page.GetText();

        }
        public void ImageTextAnalysis(Bitmap pic)
        {
            inputImage = new Image<Bgr, byte>(pic);
            BinarizeImage(inputImage.ToBitmap());

            var ocr = new TesseractEngine(Resources.IMAGEPROCESSING_PATH_dataPath, Resources.IMAGEPROCESSING_lang, EngineMode.TesseractOnly);
            var page = ocr.Process(processedImage);

            processedText = page.GetText();

        }

        public void BinarizeImage(Bitmap image)
        {
            Image<Gray, byte> imgGray;
            Image<Gray, byte> imgBinarized;

            imgGray = new Image<Gray, byte>(image);

            imgBinarized = new Image<Gray, byte>(imgGray.Width, imgGray.Height, new Gray(0));

            double thrshValue = CvInvoke.Threshold(imgGray, imgBinarized, 0, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);

            //CvInvoke.AdaptiveThreshold(imgGray, imgBinarized, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC, Emgu.CV.CvEnum.ThresholdType.Binary, 75, 74);

            //MessageBox.Show(thrshValue.ToString()); display threshold value for testing purposes

            processedImage = imgBinarized.ToBitmap();

        }
    }
}
