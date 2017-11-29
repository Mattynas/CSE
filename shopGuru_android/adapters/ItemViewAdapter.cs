using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using shopGuru_android.Model;
using shopGuru_android.interfaces;

namespace shopGuru_android.adapters
{
    class ItemViewAdapter : RecyclerView.Adapter
    {
        private List<IItem> _items;

        public override int ItemCount
        {
            get { return _items.Count(); }
        }

        public ItemViewAdapter(List<IItem> items)
        {
            _items = items;

        }

        class ItemViewHolder : RecyclerView.ViewHolder
        {
            public View MainView { get; set; }
            public TextView ItemTextView { get; set; }
            public TextView PriceTextView { get; set; }

            public ItemViewHolder(View itemView) : base(itemView)
            {
                MainView = itemView;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.view_row, parent, false);
            TextView txtItem = row.FindViewById<TextView>(Resource.Id.txtItem);
            TextView txtPrice = row.FindViewById<TextView>(Resource.Id.txtPrice);

            ItemViewHolder viewHolder = new ItemViewHolder(row) {ItemTextView = txtItem, PriceTextView = txtPrice};

            return viewHolder;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ItemViewHolder viewHolder = holder as ItemViewHolder;
            viewHolder.ItemTextView.Text = _items[position].Name;
            viewHolder.PriceTextView.Text = _items[position].Price.ToString("C");
        }
    }
}