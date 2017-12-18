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

namespace shopGuru_android.Model
{
    public class TitleItemListChild
    {
        public decimal PriceIki { get; set; }
        public decimal PriceRimi { get; set; }
        public decimal PriceMaksima { get; set; }

        public TitleItemListChild(List<Item> shopPrices)
        {
            foreach(var item in shopPrices)
            {
                switch (item.Name.ToLower())
                {
                    case "iki":
                        PriceIki = item.Price;
                        break;
                    case "rimi":
                        PriceRimi = item.Price;
                        break;
                    case "maksima":
                        PriceMaksima = item.Price;
                        break;
                }
            }
        }

    }
}