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
using shopGuru_android.authenticator;
using System.Collections.Generic;
using System.Collections;
using shopGuru_android.interfaces;

namespace shopGuru_android
{
    [Activity(Label = "shopGuru", ScreenOrientation = ScreenOrientation.Locked)]
    public class ScanActivity : AppCompatActivity, ISurfaceHolderCallback, Detector.IProcessor
    {

        private SurfaceView _cameraView;
        private TextView _textView;
        private CameraSource _cameraSource;
        private SurfaceView _transparentView;
        public static List<IItem> ItemList { get; set; }
        private int _numerator;
        private int _threshold = 5;
        private int _prevCount;
        


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
            SetContentView(Resource.Layout.activity_scanner);
            _cameraView = FindViewById<SurfaceView>(Resource.Id.surface_view);
            _textView = FindViewById<TextView>(Resource.Id.text_view);
            _transparentView = FindViewById<SurfaceView>(Resource.Id.transparent_view);

            _transparentView.SetZOrderOnTop(true);
            _transparentView.Holder.SetFormat(Format.Transparent);

            _numerator = _prevCount = 0;
            //ReceiptTextValidation.OnValidationComplete();


            var textRecognizer = new TextRecognizer.Builder(ApplicationContext).Build();

            if (!textRecognizer.IsOperational)
            {
                Log.Error("Scan Activity", "Detector dependencies not yet available");
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
            //var canvas = _transparentView.Holder.LockCanvas();
            //canvas.DrawColor(Color.Transparent, PorterDuff.Mode.Clear);
           // _transparentView.Holder.UnlockCanvasAndPost(canvas);

            SparseArray items = detections.DetectedItems;
            
            if (items.Size() != 0)
            {
                _textView.Post(() =>
                {
                    try
                    {
                        //var tuple = ReceiptTextValidation.ValidateItems(items);
                        ItemList = ReceiptValidator.ValidateItems(items);
                        //ItemList = tuple.Item1;
                        StringBuilder sb = new StringBuilder();
                        _textView.SetTextColor(Android.Graphics.Color.Red);
                        foreach(var item in ItemList)
                        {
                            sb.Append("name: " + item.Name + "price" + item.Price + "\n");
                        }
                        //sb.Append(tuple.Item2);
                        _textView.Text = sb.ToString();

                        // test if item list size doesnt change between scanning frames threshold times
                        if(ItemList.Count == _prevCount && _prevCount != 0)
                        {
                            _numerator++;
                        } 
                        else
                        {
                            _prevCount = ItemList.Count;
                            _numerator = 0;
                        }

                        if (_numerator >= _threshold)
                        {
                            _textView.SetTextColor(Android.Graphics.Color.White);
                            _textView.Text = sb.ToString();


                            Intent intent = new Intent(this, typeof(MainActivity))
                            .SetFlags(ActivityFlags.ReorderToFront);
                            SetResult(Result.Ok, intent);
                            Finish();
                        }
                    }
                    catch (System.Exception e)
                    {
                        _textView.Text = e.ToString();
                    }
                });
            }
        }

        public void Release()
        {
            return;
        }
    }
}

