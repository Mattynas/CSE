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
using shopGuru_android.Model;

namespace shopGuru_android.adapters
{
    class ItemListViewAdapter : BaseAdapter<Item>
    {
        private List<Item> _items;
        private Context _context;

        public ItemListViewAdapter(Context context, List<Item> items)
        {
            _context = context;
            _items = items;

        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override Item this[int position]
        {
            get { return _items[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            ItemListViewAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ItemListViewAdapterViewHolder;

            if (holder == null)
            {
                holder = new ItemListViewAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                view = inflater.Inflate(Resource.Layout.listview_row, parent, false);

                holder.ItemTextView = view.FindViewById<TextView>(Resource.Id.txtItem);
                holder.PriceTextView = view.FindViewById<TextView>(Resource.Id.txtPrice);


                view.Tag = holder;
            }

            holder.ItemTextView.Text = _items[position].Name;
            holder.PriceTextView.Text = _items[position].Price.ToString("C");

            return view;
        }


        public override int Count
        {
            get
            {
                return _items.Count();
            }
        }

    }

    class ItemListViewAdapterViewHolder : Java.Lang.Object
    {
        public TextView ItemTextView { get; set; }
        public TextView PriceTextView { get; set; }
    }
}