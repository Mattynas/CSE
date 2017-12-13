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
using System.Web;
using System.Threading.Tasks;

namespace shopGuru_android.controller
{
    public static class DataController
    {

        public static async Task<string> LotteryDataSubmition(Dictionary<string,string> values)
        {
            string dateformat = "T00:00:00+02:00";

            values["ticket_date"] += dateformat;
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

            return result;
        }

        public static async Task<bool> LoginDataSubmition(string username, string password)
        {
            var client = new WebService.shopGuru_webService();

            var success = false;

            success = await Task.Run(() => client.Login(username, password));
            return success;
        }

        public static bool RegisterDataSubmition(string name, string password, string email, string phone)
        {
            //User clicked the button
            var client = new WebService.shopGuru_webService();
            var success = client.Register(name,password,email,phone);
            return success;

        }
    }
}