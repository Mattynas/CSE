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
    public class WeightedItem: IItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
    }
}