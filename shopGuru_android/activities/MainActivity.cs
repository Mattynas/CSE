using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using shopGuru_android.Model;
using shopGuru_android.fragments;
using shopGuru_android.converters;
using shopGuru_android.interfaces;
using Android.Content.PM;

namespace shopGuru_android
{
    [Activity(Label = "shopGuru", ScreenOrientation = ScreenOrientation.Locked)]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout _drawerLayout;
        private NavigationView _navigationView;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);



            SetContentView(Resource.Layout.activity_main);
            
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            _navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            
            SetSupportActionBar(toolbar);
            var drawerToggle = new Android.Support.V7.App.ActionBarDrawerToggle(this, _drawerLayout, Resource.String.drawer_open,
                Resource.String.drawer_close);

            //_drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
            
            
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_black_24dp);
            
            
            _navigationView.NavigationItemSelected += (sender, e) => {
                
                 e.MenuItem.SetChecked(true);
                
                //react to click here and swap fragments or navigate
                long id = e.MenuItem.ItemId;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                if (id == Resource.Id.nav_scanner)
                {
                    var intent = new Intent(this,typeof(ScanActivity));
                    StartActivityForResult(intent, 0);
                }
                else if (id == Resource.Id.nav_processing)
                {
                    var intent = new Intent(this, typeof(ImageProcessingActivity));
                    StartActivityForResult(intent, 0);
                }
                

                _drawerLayout.CloseDrawers();
            };
        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                
                try
                {
                    var itemList = ScanActivity.ItemList;
                    var trans = SupportFragmentManager.BeginTransaction();
                    trans.Add(Resource.Id.fragmentContainer, new ItemListFragment(itemList), "ItemListFragment");
                    trans.Commit();
                }
                catch (FormatException ex)
                {
                    Toast.MakeText(ApplicationContext,ex.Message,ToastLength.Long).Show();
                }
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            _navigationView.InflateMenu(Resource.Menu.menu); //Navigation Drawer Layout Menu Creation  
            return true;
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

