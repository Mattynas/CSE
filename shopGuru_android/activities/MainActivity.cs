﻿using System;
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
using SupportFragment = Android.Support.V4.App.Fragment;
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
        private SupportFragment _currFragment;
        private Stack<SupportFragment> _stackFragment;

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

            _drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
            
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_black_24dp);

            _stackFragment = new Stack<SupportFragment>();

            // add fragments to layout and hide all except for main
            var mainFragment = new MainFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            trans.Add(Resource.Id.fragmentContainer, mainFragment, mainFragment.Id.ToString());
            trans.Commit();

            _currFragment = mainFragment;

            _navigationView.NavigationItemSelected += (sender, e) => {
                
                
                 e.MenuItem.SetChecked(true);
                //react to click here and swap fragments or navigate
                long id = e.MenuItem.ItemId;
                switch(id)
                {
                    case Resource.Id.nav_lottery:
                        var receiptLotteryFragment = new ReceiptLotteryFragment();
                        ShowFragment(receiptLotteryFragment);
                        break;
                    case Resource.Id.nav_home:
                        ShowFragment(mainFragment);
                        break;

                    case Resource.Id.nav_nearestshop:
                        ShowFragment(new NearestShopFragment());
                        break;
                }
                 
                _drawerLayout.CloseDrawers();
            };

        }
        
        private void ShowFragment(SupportFragment fragment)
        {
            var trans = SupportFragmentManager.BeginTransaction();

            SupportFragment ftemp = SupportFragmentManager.FindFragmentById(fragment.Id);

            if (ftemp == null)
            {
                trans.Add(Resource.Id.fragmentContainer, fragment, fragment.Id.ToString());
            }
            trans.Hide(_currFragment);
            trans.Show(fragment);
            trans.AddToBackStack(null);
            trans.Commit();

            _stackFragment.Push(_currFragment);
            _currFragment = fragment;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                
                try
                {
                    var itemList = ScanActivity.ItemList;
                    var itemListFragment = new ItemListFragment(itemList);

                    ShowFragment(itemListFragment);
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

        public override void OnBackPressed()
        {
            if(SupportFragmentManager.BackStackEntryCount > 0)
            {
                SupportFragmentManager.PopBackStack();
                _currFragment = _stackFragment.Pop();
            }
            else
            {
                base.OnBackPressed();
            } 
        }
    }
}

