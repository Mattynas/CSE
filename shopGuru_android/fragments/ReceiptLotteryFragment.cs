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
using System.Web;

namespace shopGuru_android.fragments
{
    public class ReceiptLotteryFragment : Android.Support.V4.App.Fragment
    {
        private Button _button;
        private TextView _errorTxt;
        private RadioButton _radio_market;
        private RadioButton _radio_services;
        private EditText _cashRegisterNumber;
        private EditText _receiptNumber;
        private EditText _receiptDate;

        private Dictionary<string, string> values = new Dictionary<string, string>();

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
            _errorTxt = view.FindViewById<TextView>(Resource.Id.txtError);
            _radio_market = view.FindViewById<RadioButton>(Resource.Id.radio_market);
            _radio_services = view.FindViewById<RadioButton>(Resource.Id.radio_services);
            _cashRegisterNumber = view.FindViewById<EditText>(Resource.Id.txtCshRegNum);
            _receiptNumber = view.FindViewById<EditText>(Resource.Id.txtRcpNum);
            _receiptDate = view.FindViewById<EditText>(Resource.Id.txtDate);

            _radio_market.Click += RadioButton_Click;
            _radio_services.Click += RadioButton_Click;
            _button.Click += _button_ClickAsync;

            base.OnCreateView(inflater, container, savedInstanceState);
            return view;
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            values["check_type"] = rb.Text;
        }

        private async void _button_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                string date = _receiptDate.Text;
                date += "T00:00:00+02:00";
                values["cash_register_number"] = _cashRegisterNumber.Text;
                values["check_number"] = _receiptNumber.Text;
                values["phone"] = "+37066666666";
                values["ticket_date"] = date;
                values["agree_on_terms"] = "true";

                var sb = new StringBuilder();
                foreach (var item in values)
                {
                    sb.AppendFormat("{0}={1}&", item.Key, HttpUtility.UrlEncode(item.Value.ToString()));
                }
                sb.Remove(sb.Length - 1, 1);
                byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());

                var client = new WebService.shopGuru_webService();

                string result = await Task.Run(() => client.FillLotteryForm(bytes));

                _errorTxt.Text = result;
                
            }
            catch(Exception ex)
            {
                _errorTxt.Text = ex.ToString();
            }
        }
    }
}