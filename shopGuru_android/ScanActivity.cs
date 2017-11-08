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
using Java.Lang;

namespace shopGuru_android
{
    [Activity(Label = "shopGuru")]
    public class ScanActivity : AppCompatActivity, ISurfaceHolderCallback, Detector.IProcessor
    {
        private SurfaceView _cameraView;
        private TextView _textView;
        private CameraSource _cameraSource;
        private const int RequestCameraPermissionId = 1001;

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            switch (requestCode)
            {
                case RequestCameraPermissionId:
                    {
                        if (grantResults[0] == Permission.Granted)
                        {
                            _cameraSource.Start(_cameraView.Holder);
                        }
                    }
                    break;
            }

        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Set your main view here
            SetContentView(Resource.Layout.scanner);
            _cameraView = FindViewById<SurfaceView>(Resource.Id.surface_view);
            _textView = FindViewById<TextView>(Resource.Id.text_view);

            var textRecognizer = new TextRecognizer.Builder(ApplicationContext).Build();

            if (!textRecognizer.IsOperational)
            {
                Log.Error("Main Activity", "Detector dependencies not yet available");
            }
            else
            {
                _cameraSource = new CameraSource.Builder(ApplicationContext, textRecognizer)
                    .SetFacing(CameraFacing.Back)
                    .SetRequestedPreviewSize(1280, 1024)
                    .SetRequestedFps(2.0f)
                    .SetAutoFocusEnabled(true)
                    .Build();
                _cameraView.Holder.AddCallback(this);
                textRecognizer.SetProcessor(this);
            }

        }


        public void SurfaceChanged(ISurfaceHolder holder, Format format, int width, int height)
        {

        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            if (ActivityCompat.CheckSelfPermission(ApplicationContext, Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[]
                {
                    Android.Manifest.Permission.Camera
                }, RequestCameraPermissionId);
                return;
            }

            _cameraSource.Start(_cameraView.Holder);
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            _cameraSource.Stop();
        }

        public void ReceiveDetections(Detector.Detections detections)
        {
            SparseArray items = detections.DetectedItems;
            if (items.Size() != 0)
            {
                _textView.Post(() =>
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < items.Size(); i++)
                    {
                        sb.Append(((TextBlock)items.ValueAt(i)).Value);
                        sb.Append("\n");
                    }
                    _textView.Text = sb.ToString();
                });
            }
        }

        public void Release()
        {
            return;
        }
    }
}

