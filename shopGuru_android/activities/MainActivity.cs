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
using SupportFragment = Android.Support.V4.App.Fragment;
using shopGuru_android.Model;
using shopGuru_android.fragments;
using shopGuru_android.converters;
using shopGuru_android.interfaces;
using Android.Content.PM;
using shopGuru_android.authenticator;

namespace shopGuru_android
{
    [Activity(Label = "shopGuru", ScreenOrientation = ScreenOrientation.Locked,MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout _drawerLayout;
        private NavigationView _navigationView;
        private SupportFragment _currFragment;
        private Stack<SupportFragment> _stackFragment;
        private List<IItem> itemList;
        private SupportFragment confirmedListFragment;

        public static readonly int requestScannerId = 0;
        public static readonly int requestLotteryScannerId = 1;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // login check 
            var prefs = new AppPreferences(this.ApplicationContext);
            if(prefs.GetUserName().Length == 0)
            {
                var intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
                Finish();
            }


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

            var nav_header = _navigationView.GetHeaderView(0).FindViewById<TextView>(Resource.Id.navheader_username);
            if (this.Intent.Extras != null)
            {
                var name = this.Intent.Extras.GetString("name");
                if (nav_header != null) nav_header.Text = name;
            }
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
                        var receiptLotteryMainFragment = new ReceiptLotteryMainFragment();
                        ShowFragment(receiptLotteryMainFragment);
                        break;
                    case Resource.Id.nav_home:
                        ShowFragment(mainFragment);
                        break;
                    case Resource.Id.nav_signout:
                        var ap = new AppPreferences(this.ApplicationContext);
                        ap.SaveUserName("");
                        var intent = new Intent(this, typeof(LoginActivity));
                        StartActivity(intent);
                        Finish();
                        break;
                        
                    case Resource.Id.nav_yourReceipt:
                        if(itemList != null)
                        {
                            ShowFragment(confirmedListFragment);
                        }
                        else
                        {
                            ShowFragment(mainFragment);
                            Toast.MakeText(ApplicationContext, "Please scan receipt first!", ToastLength.Long).Show();
                        }
                        break;
                        /*
                    case Resource.Id.nav_about:
                        var aboutFragment = new AboutFragment();
                        ShowFragment(aboutFragment);
                        break;
                    case Resource.Id.nav_statistics:
                        var statisticsFragment = new StatisticsFragment();
                        ShowFragment(statisticsFragment);
                        break;
                    case Resource.Id.nav_settings:
                        var settingsFragment = new SettingsFragment();
                        ShowFragment(settingsFragment);
                        break;
                        */
                }

                _drawerLayout.CloseDrawers();
            };

        }
        
        private void ShowFragment(SupportFragment fragment)
        {
            var trans = SupportFragmentManager.BeginTransaction();
            System.Diagnostics.Debug.WriteLine("fragment tag: " + fragment.Id.ToString());
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
                if(requestCode == requestScannerId)
                {   
                    try
                    {
                        itemList = ScanActivity.ItemList;
                        var itemListFragment = new ItemListFragment(itemList);

                        ShowFragment(itemListFragment);
                    }
                    catch (FormatException ex)
                    {
                        Toast.MakeText(ApplicationContext,ex.Message,ToastLength.Long).Show();
                    }

                }
                else if(requestCode == requestLotteryScannerId)
                {
                    var results = ReceiptLotteryScanActivity.dictionary;
                    var receiptLotteryFragment = new ReceiptLotteryFragment(results);

                    ShowFragment(receiptLotteryFragment);
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

        public void StartNewFragment(SupportFragment fragment)
        {
            confirmedListFragment = fragment;
            ShowFragment(fragment);
        }

    }
}

