using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using shopGuru_android.adapters;
using shopGuru_android.interfaces;
using Android.Support.V7.Widget;

namespace shopGuru_android.fragments
{
    public class ItemListFragment : Android.Support.V4.App.Fragment
    {
        private RecyclerView _recyclerView;
        private FrameLayout _subfragContainer;
        private List<IItem> itemList;

        public ItemListFragment(List<IItem> itemList)
        {
            this.itemList = itemList;
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.fragment_itemList, container, false);

            _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var layoutManager = new LinearLayoutManager(Activity);
            var itemAdapter = new ItemViewAdapter(itemList);
            _recyclerView.SetLayoutManager(layoutManager);
            _recyclerView.SetAdapter(itemAdapter);

            return view;
        }
    }
}