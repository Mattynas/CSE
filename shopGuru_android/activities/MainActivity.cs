using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using shopGuru_android.Model;
using shopGuru_android.adapters;

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
            var intent = new Intent(this, typeof(ImageProcessingActivity));
            StartActivity(intent);
            //Set your main view here

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
                _drawerLayout.CloseDrawers();
            };


            // RecyclerView

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var itemList = new List<Item>
            {
                new Item {Name = "suris", Price = 0.5f},
                new Item {Name = "kefyras", Price = 0.4f},
                new Item {Name = "bulka", Price = 3.45f},
                new Item {Name = "kopustas", Price = 2.54f},
                new Item {Name = "dzinas", Price = 8.45f}
            };

            var layoutManager = new LinearLayoutManager(this);
            var itemAdapter = new ItemViewAdapter(itemList);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(itemAdapter);

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

