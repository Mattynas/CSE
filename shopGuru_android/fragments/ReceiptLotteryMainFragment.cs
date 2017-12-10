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

namespace shopGuru_android.fragments
{
    public class ReceiptLotteryMainFragment : Android.Support.V4.App.Fragment
    {
        private Button _btnScan;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var view = inflater.Inflate(Resource.Layout.fragment_mainLottery, container, false);

            _btnScan = view.FindViewById<Button>(Resource.Id.btnLotteryScanner);
            _btnScan.Click += _btnScan_Click;
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            
            base.OnCreateView(inflater, container, savedInstanceState);
            return view;
        }

        private void _btnScan_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Context, typeof(ReceiptLotteryScanActivity));
            this.Activity.StartActivityForResult(intent,MainActivity.requestLotteryScannerId);
        }
    }
}