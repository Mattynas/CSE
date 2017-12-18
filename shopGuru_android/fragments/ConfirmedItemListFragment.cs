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
using Android.Support.V7.Widget;
using shopGuru_android.adapters;
using XamDroid.ExpandableRecyclerView;
using shopGuru_android.Model;
using shopGuru_android.interfaces;
using shopGuru_android.controller;
using System.Threading.Tasks;

namespace shopGuru_android.fragments
{
    public class ConfirmedItemListFragment : Android.Support.V4.App.Fragment
    {
        RecyclerView recyclerView;
        List<IItem> receiptItemList;

        public ConfirmedItemListFragment(List<IItem> receiptItemList)
        {
            this.receiptItemList = receiptItemList;
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            ((ExpRecyclerViewAdapter)recyclerView.GetAdapter()).OnSaveInstanceState(outState);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_itemListCardView, container, false);

            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.cardViewRecycler);
            var layoutManager = new LinearLayoutManager(this.Activity);
            var adapter = new ExpRecyclerViewAdapter(this.Activity, InitData(receiptItemList));
            adapter.CustomParentAnimationViewId = Resource.Id.expandArrow;
            adapter.SetParentClickableViewAnimationDefaultDuration();
            adapter.ParentAndIconExpandOnClick = true;

            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);
            return view;
        }
        private  List<IParentObject> InitData(List<IItem> itemList)
        {
            var titleCreator = TitleCreator.Get(this.Activity, itemList);
            var titles = titleCreator.GetAll;
            var parentObject = new List<IParentObject>();
            var i = 0;
            foreach (var title in titles)
            {
                var childList = new List<object>();
                var priceList = DataController.GetPricesByItem(title.Title);

                Item currPrice = new Item();
                currPrice.Name = "current";
                currPrice.Price = itemList.ElementAt(i).Price;
                i++;
                priceList.Add(currPrice);

                childList.Add(new TitleItemListChild(priceList));
                title.ChildObjectList = childList;
                parentObject.Add(title);
            }

            return parentObject;
        }
    }
}