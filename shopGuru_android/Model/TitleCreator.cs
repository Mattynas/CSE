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
using shopGuru_android.interfaces;

namespace shopGuru_android.Model
{
    public class TitleCreator
    {
        static TitleCreator _titleCreator;
        Context context;
        List<TitleItemListParent> _titleParents;
        List<IItem> itemList;

        public TitleCreator(Context context, List<IItem> itemList)
        {
            this.itemList = itemList;
            _titleParents = new List<TitleItemListParent>();
            foreach(var item in itemList)
            {
                var title = new TitleItemListParent()
                {
                    Title = item.Name
                };
            _titleParents.Add(title);
            }
        }

        public static TitleCreator Get(Context context, List<IItem> itemList)
        {
            if (_titleCreator == null)
                _titleCreator = new TitleCreator(context, itemList);
            return _titleCreator;
        }

        public List<TitleItemListParent> GetAll
        {
            get
            {
                return _titleParents;
            }
            private set
            {

            }
        }
    }
}