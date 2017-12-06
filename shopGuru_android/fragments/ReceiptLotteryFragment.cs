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
using System.Threading.Tasks;

namespace shopGuru_android.fragments
{
    public class ReceiptLotteryFragment : Android.Support.V4.App.Fragment
    {
        private Button _button;

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
            _button = view.FindViewById<Button>(Resource.Id.btnLotteryScan);

            _button.Click += _button_ClickAsync;

            base.OnCreateView(inflater, container, savedInstanceState);
            return view;
        }

        private async void _button_ClickAsync(object sender, EventArgs e)
        {
            Dictionary<string,string> values = new Dictionary<string, string>();
            values.Add("check_type", "services");
            values.Add("cash_register_number", "RK123456");
            values.Add("check_number", "00000004");
            values.Add("created_at", "2017-12-06T16:06:04.054428Z");
            values.Add("phone", "+37066666666");
            values.Add("ticket_date", "2017-11-29T00:00:00+02:00");

            var client = new WebService.shopGuru_webService();

            string result = await Task.Run(() => client.FillLotteryForm(values));

        }
    }
}