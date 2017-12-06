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
    class ItemViewAdapter : RecyclerView.Adapter, IItemClickListener
    {
        private List<IItem> _items;
        private Context context;
        public event EventHandler<int> itemClick;

        public ItemViewAdapter(List<IItem> items, Context context)
        {
            _items = items;
            this.context = context;
        }

        public void UpdateItemList(List<IItem> itemList)
        {
            this._items = itemList;
        }

        public override int ItemCount
        {
            get { return _items.Count(); }
        }

        class ItemViewHolder : RecyclerView.ViewHolder, View.IOnClickListener, View.IOnLongClickListener
        {
            public View MainView { get; set; }
            public TextView ItemTextView { get; set; }
            public TextView PriceTextView { get; set; }

            private IItemClickListener itemClickListener;

            public ItemViewHolder(View itemView) : base(itemView)
            {
                MainView = itemView;
                itemView.SetOnClickListener(this);
                itemView.SetOnLongClickListener(this); 
            }

            public void SetItemClickListener(IItemClickListener itemClickListener)
            {
                this.itemClickListener = itemClickListener;
            }

            public void OnClick(View v)
            {
                itemClickListener.OnClick(v, AdapterPosition, false);
            }

            public bool OnLongClick(View v)
            {
                itemClickListener.OnClick(v, AdapterPosition, true);
                return true;
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
            viewHolder.SetItemClickListener(this);
        }

        public void OnClick(View itemView, int position, bool isLongClick)
        {
            if (isLongClick)
            {
                if (itemClick != null) itemClick(this, position);
            }
        }
    }
}