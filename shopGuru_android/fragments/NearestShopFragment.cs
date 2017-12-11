using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;

namespace shopGuru_android.fragments
{
    public class NearestShopFragment : Android.Support.V4.App.Fragment, IOnMapReadyCallback
    {
        private GoogleMap mMap;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            var view = inflater.Inflate(Resource.Layout.fragment_findNearestShop, container, false);
            base.OnCreateView(inflater, container, savedInstanceState);
            return view;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
        }
    }
}