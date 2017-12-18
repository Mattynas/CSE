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
using shopGuru_android.ViewHolder;
using shopGuru_android.Model;
using Android.Support.V7.Widget;

namespace shopGuru_android.adapters
{
    public class ExpRecyclerViewAdapter : ExpandableRecyclerAdapter<ItemListParentViewHolder, ItemListChildViewHolder>
    {
        LayoutInflater _infalter;

        public ExpRecyclerViewAdapter(Context context, List<IParentObject> itemList):base(context, itemList)
        {
            _infalter = LayoutInflater.From(context);
        }

        public override void OnBindChildViewHolder(ItemListChildViewHolder childViewHolder, int position, object childObject)
        {
            var title = (TitleItemListChild)childObject;
            childViewHolder.currPrice.Text = title.PriceCurrent.ToString("C");
            childViewHolder.price1.Text = title.PriceIki.ToString("C");
            childViewHolder.price2.Text = title.PriceRimi.ToString("C");
            childViewHolder.price3.Text = title.PriceMaksima.ToString("C");

        }

        public override void OnBindParentViewHolder(ItemListParentViewHolder parentViewHolder, int position, object parentObject)
        {
            var title = (TitleItemListParent)parentObject;
            parentViewHolder._textView.Text = title.Title;
        }

        public override ItemListChildViewHolder OnCreateChildViewHolder(ViewGroup childViewGroup)
        {
            var view = _infalter.Inflate(Resource.Layout.itemListCardView_child, childViewGroup, false);
            return new ItemListChildViewHolder(view);
        }

        public override ItemListParentViewHolder OnCreateParentViewHolder(ViewGroup parentViewGroup)
        {
            var view = _infalter.Inflate(Resource.Layout.ItemListCardView, parentViewGroup, false);
            return new ItemListParentViewHolder(view);
        }
    }
}