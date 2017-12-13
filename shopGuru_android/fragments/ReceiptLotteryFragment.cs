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
using shopGuru_android.controller;
using Android.Support.Design.Widget;

namespace shopGuru_android.fragments
{
    public class ReceiptLotteryFragment : Android.Support.V4.App.Fragment
    {
        private Button _button;
        private TextView _errorTxt;
        private RadioButton _radio_market;
        private RadioButton _radio_services;
        private TextInputEditText _cashRegisterNumber;
        private TextInputEditText _receiptNumber;
        private TextInputEditText _receiptDate;
        private TextInputEditText _phoneNumber;

        private Dictionary<string, string> values;

        public ReceiptLotteryFragment(Dictionary<string,string> results)
        {
            values = results;
        }

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
            _button = view.FindViewById<Button>(Resource.Id.btnLotterySubmit);
            _errorTxt = view.FindViewById<TextView>(Resource.Id.txtError);
            _radio_market = view.FindViewById<RadioButton>(Resource.Id.radio_market);
            _radio_services = view.FindViewById<RadioButton>(Resource.Id.radio_services);
            _cashRegisterNumber = view.FindViewById<TextInputEditText>(Resource.Id.txtCshRegNum);
            _receiptNumber = view.FindViewById<TextInputEditText>(Resource.Id.txtRcpNum);
            _receiptDate = view.FindViewById<TextInputEditText>(Resource.Id.txtDate);
            _phoneNumber = view.FindViewById<TextInputEditText>(Resource.Id.txt_phone_number);

            _receiptDate.Text = values["ticket_date"];
            _cashRegisterNumber.Text = values["cash_register_number"];
            _receiptNumber.Text = values["check_number"];

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
                values["phone"] = _phoneNumber.Text;

                string result = await DataController.LotteryDataSubmition(values);

                _errorTxt.Text = result;
                
            }
            catch(Exception ex)
            {
                _errorTxt.Text = ex.ToString();
            }
        }
    }
}