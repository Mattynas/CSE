using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;


namespace WindowsFormsCSE.ImageProcessing
{
    class ImageCroping
    {
        private Point RectStartPoint;
        private Rectangle Rect = new Rectangle();
        private Rectangle RealImageRect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 64, 64, 64));
        private Image<Bgr, byte> newImage;

        public void SetRectStartPoint(MouseEventArgs e) { this.RectStartPoint = e.Location; }

        public Bitmap GetCropedImage { get { return this.newImage.ToBitmap(); } }

        public void SetNewRectangle() { this.Rect = new Rectangle(); }

        public void DrawROI(string imageFile, PictureBox pic, MouseEventArgs e)
        {
            int X0, Y0;
            ConvertCoordinates(pic, out X0, out Y0, e.X, e.Y);

            //Coordinates of input picture box
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));

            //Create ROI
            ConvertCoordinates(pic, out X0, out Y0, RectStartPoint.X, RectStartPoint.Y);
            int X1, Y1;
            ConvertCoordinates(pic, out X1, out Y1, tempEndPoint.X, tempEndPoint.Y);
            RealImageRect.Location = new Point(
                Math.Min(X0, X1),
                Math.Min(Y0, Y1));
            RealImageRect.Size = new Size(
                Math.Abs(X0 - X1),
                Math.Abs(Y0 - Y1));

            newImage = new Image<Bgr, byte>(imageFile);
        }

        public void SelectROI(object sender, PaintEventArgs e)
        {
            if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
            {
                e.Graphics.SetClip(Rect, System.Drawing.Drawing2D.CombineMode.Exclude);
                e.Graphics.FillRectangle(selectionBrush, new Rectangle(0, 0, ((PictureBox)sender).Width, ((PictureBox)sender).Height));
            }
        }

        public void DefineROI()
        {
            if (RealImageRect.Width > 0 && RealImageRect.Height > 0)
            {
                newImage.ROI = RealImageRect;
            }
        }

        private void ConvertCoordinates(PictureBox pic, out int X0, out int Y0, int x, int y)
        {
            int pic_hgt = pic.ClientSize.Height;
            int pic_wid = pic.ClientSize.Width;
            int img_hgt = pic.Image.Height;
            int img_wid = pic.Image.Width;

            X0 = x;
            Y0 = y;
            switch (pic.SizeMode)
            {
                case PictureBoxSizeMode.AutoSize:
                case PictureBoxSizeMode.Normal:
                    break;

                case PictureBoxSizeMode.CenterImage:
                    X0 = x - (pic_wid - img_wid) / 2;
                    Y0 = y - (pic_hgt - img_hgt) / 2;
                    break;

                case PictureBoxSizeMode.StretchImage:
                    X0 = (int)(img_wid * x / (float)pic_wid);
                    Y0 = (int)(img_hgt * y / (float)pic_hgt);
                    break;

                case PictureBoxSizeMode.Zoom:
                    float pic_aspect = pic_wid / (float)pic_hgt;
                    float img_aspect = img_wid / (float)img_wid;
                    if (pic_aspect < img_aspect)
                    {
                        // Image is wider/taller than picture box
                        Y0 = (int)(img_hgt * y / (float)pic_hgt);

                        float scaled_width = img_wid * pic_hgt / img_hgt;
                        float dx = (pic_wid - scaled_width) / 2;
                        X0 = (int)((x - dx) * img_hgt / (float)pic_hgt);
                    }
                    else
                    {
                        // PictureBox is wider/taller than image
                        X0 = (int)(img_wid * x / (float)pic_wid);

                        float scaled_height = img_hgt * pic_wid / img_wid;
                        float dy = (pic_hgt - scaled_height) / 2;
                        Y0 = (int)((y - dy) * img_wid / pic_wid);
                    }
                    break;

            }
        }

    }
}
