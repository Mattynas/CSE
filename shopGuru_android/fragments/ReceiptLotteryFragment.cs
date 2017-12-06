using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Collections.Specialized;

namespace shopGuru_android.fragments
{
    public class ReceiptLotteryFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var view = inflater.Inflate(Resource.Layout.fragment_receiptLottery, container, false);


            NameValueCollection values = new NameValueCollection();
            values.Add("check_type", "services");
            values.Add("cash_register_number", "RK123456");


            base.OnCreateView(inflater, container, savedInstanceState);
            return view;
        }
    }
}