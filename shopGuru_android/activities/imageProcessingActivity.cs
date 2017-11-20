using System;
using System.Runtime.CompilerServices;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Vision;
using Android.Gms.Vision.Texts;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Util;
using Android.Net;
using Java.Lang;
using Android.Provider;
using Java.IO;
using System.Collections.Generic;
using Android.Media;
using shopGuru_android.authenticator;

namespace shopGuru_android
{
    [Activity(Label = "shopGuru")]
    public class ImageProcessingActivity : AppCompatActivity
    {
        private ImageView imageView;
        private Button camButton;
        private TextView txtResult;
        private Button processButton;
        private Bitmap img;

        private  File file;
        private File dir;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_imageProcess);

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

                camButton = FindViewById<Button>(Resource.Id.camButton);
                processButton = FindViewById<Button>(Resource.Id.processButton);
                imageView = FindViewById<ImageView>(Resource.Id.imageView);
                txtResult = FindViewById<TextView>(Resource.Id.textResult);

                camButton.Click += CamButton_Click;

                processButton.Click += ProcessImage;
            }

        }
        private void CreateDirectoryForPictures()
        {
            dir = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "CameraAppDemo");
            if (!dir.Exists())
            {
                dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities = PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void CamButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            file = new File(dir, System.String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(file));
            StartActivityForResult(intent, 0);
            /*
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
            */
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Android.Net.Uri contentUri = Android.Net.Uri.FromFile(file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume to much memory
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = imageView.Height;
            img = LoadAndResizeBitmap(file.Path, width, height);
            if (img != null)
            {
                imageView.SetImageBitmap(img);
            }

            // Dispose of the Java side bitmap.
            GC.Collect();

            /*
            base.OnActivityResult(requestCode, resultCode, data);
            img = (Bitmap)data.Extras.Get("data");
            imageView.SetImageBitmap(img);
            */
        }

        public Bitmap LoadAndResizeBitmap(string fileName, int width, int height)
        {
            // First we get the the dimensions of the file on disk
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            // Next we calculate the ratio that we need to resize the image by
            // in order to fit the requested dimensions.
            int outHeight = options.OutHeight;
            int outWidth = options.OutWidth;
            int inSampleSize = 1;

            if (outHeight > height || outWidth > width)
            {
                inSampleSize = outWidth > outHeight
                    ? outHeight / height
                        : outWidth / width;
            }

            // Now we will load the image and have BitmapFactory resize it for us.
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

            // Images are being saved in landscape, so rotate them back to portrait if they were taken in portrait
            Matrix mtx = new Matrix();
            ExifInterface exif = new ExifInterface(fileName);
            string orientation = exif.GetAttribute(ExifInterface.TagOrientation);
            /*
            switch (orientation)
            {
                case "6": // portrait
                    mtx.PreRotate(90);
                    resizedBitmap = Bitmap.CreateBitmap(resizedBitmap, 0, 0, resizedBitmap.Width, resizedBitmap.Height, mtx, false);
                    mtx.Dispose();
                    mtx = null;
                    break;
                case "1": // landscape
                    break;
                default:
                    mtx.PreRotate(90);
                    resizedBitmap = Bitmap.CreateBitmap(resizedBitmap, 0, 0, resizedBitmap.Width, resizedBitmap.Height, mtx, false);
                    mtx.Dispose();
                    mtx = null;
                    break;
            }
            */


            return resizedBitmap;
        }

        private void ProcessImage(object sender, EventArgs e)
        {
            TextRecognizer txtRec = new TextRecognizer.Builder(ApplicationContext).Build();
            if (!txtRec.IsOperational)
            {
                Log.Error("ERROR", "Detector depedencies are not yet available");
            }
            else if (img != null)
            {
                Frame frame = new Frame.Builder().SetBitmap(img).Build();
                SparseArray items = txtRec.Detect(frame);
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); ++i)
                {
                    TextBlock item = (TextBlock) items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                if (ReceiptTextValidation.CheckTextResult(strBuilder.ToString()))
                {
                    txtResult.SetTextColor(Android.Graphics.Color.White);
                    txtResult.Text = strBuilder.ToString();

                    Intent intent = new Intent(this, typeof(MainActivity));

                    intent.PutExtra("text", strBuilder.ToString());
                    SetResult(Result.Ok, intent);
                    Finish();
                }
                else
                {
                    txtResult.Text = "Failed to read the receipt.";
                    txtResult.SetTextColor(Android.Graphics.Color.Red);
                }
            }
        }
    }
}