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
    public class ItemListParentViewHolder:ParentViewHolder
    {
        public TextView _textView;
        public ImageButton _imageButton;


        public ItemListParentViewHolder(View itemView) : base(itemView)
        {
            _textView = itemView.FindViewById<TextView>(Resource.Id.parentTitle);
            _imageButton = itemView.FindViewById<ImageButton>(Resource.Id.expandArrow);
        }
    }
}