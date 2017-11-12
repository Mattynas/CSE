using System;
using System.Linq;
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
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4;
using Android.Support.V4.Widget;
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
        private DrawerLayout _drawerLayout;
        private NavigationView _navigationView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            //var intent = new Intent(this, typeof(LoginActivity));
            //StartActivity(intent);

            //Set your main view here

            SetContentView(Resource.Layout.main);
            
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.abc_menu_hardkey_panel_mtrl_mult);
            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            _navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    _drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

