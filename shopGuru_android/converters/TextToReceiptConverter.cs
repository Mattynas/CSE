using System;
using System.Collections.Generic;
using shopGuru_android.Exceptions.Process;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using shopGuru_android.Extensions;
using shopGuru_android.Model;
using shopGuru_android.Properties;

namespace shopGuru_android.converters
{
    class TextToReceiptConverter
    {
        
        public static List<Item> ReadItemList(string receiptString)
        {
            List<Item> itemList = new List<Item>();


            try
            {
                
                
               
                return itemList;
            }
            catch (FormatException)
            {
                throw new FormatException("format error, please try again");
            }

        }
    }
}