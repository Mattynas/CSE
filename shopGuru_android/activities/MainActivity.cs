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
using shopGuru_android.adapters;
using shopGuru_android.converters;
using shopGuru_android.interfaces;

namespace shopGuru_android
{
    [Activity(Label = "shopGuru")]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout _drawerLayout;
        private NavigationView _navigationView;
        private RecyclerView _recyclerView;

        private Intent _intent;

        public delegate string GenericDelegateNumber<T1,T2>(T1 a,T2 b);

        public static string AddDoubles(double a, double b)
        {
            return (a + b).ToString();
        }

        public static string AddInt(int a, int b)
        {
            return (a + b).ToString();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            GenericDelegateNumber<int, int> gdInt = new GenericDelegateNumber<int, int>(AddInt);
            GenericDelegateNumber<double, double> gdDouble = new GenericDelegateNumber<double, double>(AddDoubles);

            Console.WriteLine(gdInt(5, 6));
            Console.WriteLine(gdDouble(6.5, 4.3));


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
            
            
            _navigationView.NavigationItemSelected += (sender, e) => {
                
                 e.MenuItem.SetChecked(true);
                
                //react to click here and swap fragments or navigate
                long id = e.MenuItem.ItemId;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                if (id == Resource.Id.nav_scanner)
                {
                    _intent = new Intent(this,typeof(ScanActivity));
                }
                else if (id == Resource.Id.nav_processing)
                {
                    _intent = new Intent(this, typeof(ImageProcessingActivity));
                }
                else if (id == Resource.Id.nav_home)
                {
                    //return;
                }
                
                if (_intent != null)
                {
                    StartActivityForResult(_intent,0);
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
                    ToRecyclerView(itemList);
                }
                catch (FormatException ex)
                {
                    Toast.MakeText(ApplicationContext,ex.Message,ToastLength.Long).Show();
                }
            }
        }

        private void ToRecyclerView(List<IItem> itemList)
        {
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var layoutManager = new LinearLayoutManager(this);
            var itemAdapter = new ItemViewAdapter(itemList);
            _recyclerView.SetLayoutManager(layoutManager);
            _recyclerView.SetAdapter(itemAdapter);
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

