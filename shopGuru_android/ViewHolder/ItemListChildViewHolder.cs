using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamDroid.ExpandableRecyclerView;

namespace shopGuru_android.ViewHolder
{
    public class ItemListChildViewHolder:ChildViewHolder
    {
        public TextView price1, price2, price3, currPrice, text1, text2, text3, text4;

        public ItemListChildViewHolder(View itemView) : base(itemView)
        {
            currPrice = itemView.FindViewById<TextView>(Resource.Id.priceText1);
            price1 = itemView.FindViewById<TextView>(Resource.Id.priceText2);
            price2 = itemView.FindViewById<TextView>(Resource.Id.priceText3);
            price3 = itemView.FindViewById<TextView>(Resource.Id.priceText4);
        }
    }
}