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
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace shopGuru_android
{
    [Activity(Label = "shopGuru", MainLauncher = true,
        Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        private Toolbar _toolbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var intent = new Intent(this,typeof(LoginActivity));
            StartActivity(intent);

            //Set your main view here

            SetContentView(Resource.Layout.main);
            //_toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //_toolbar?.SetTitle(Resource.String.app_name);
            

        }
    }
}

