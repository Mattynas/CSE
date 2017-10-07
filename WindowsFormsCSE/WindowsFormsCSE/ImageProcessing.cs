using System.Drawing;
using Tesseract;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WindowsFormsCSE
{
    class ImageProcessing
    {
        public static Image<Gray, byte> ImageBinarization(Image<Bgr, byte> ImgInput)
        {
            Image<Gray, byte> ImgGray;
            Image<Gray, byte> ImgBinarized;

            ImgGray = ImgInput.Convert<Gray, byte>();

            ImgBinarized = new Image<Gray, byte>(ImgGray.Width, ImgGray.Height, new Gray(0));

            CvInvoke.Threshold(ImgGray, ImgBinarized, 70, 255, Emgu.CV.CvEnum.ThresholdType.Binary);

            return ImgBinarized;
        }

        public static Page AnalyseImageText(Bitmap img)
        {
            var ocr = new TesseractEngine(@"../../tessdata", "lit", EngineMode.TesseractOnly);
            var page = ocr.Process(img);

            return page;
        }
    }
}
