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
using shopGuru_android.Model;

namespace shopGuru_android.controller
{
    public static class DataController
    {

        public static async Task<string> LotteryDataSubmition(Dictionary<string,string> values)
        {
            string dateformat = "T00:00:00+02:00";
            string dummy = "2017-12-11T00:00:00+02:00";

            values["ticket_date"] = "2017-12-10T00:00:00+02:00";
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
        /*
        public static async Task<List<Item>> GetPricesByItem(string name)
        {
            var pricesList = new List<Item>();
            var client = new WebService.shopGuru_webService();
            var prices = await Task.Run(() => client.GetPrices(name));
            Console.WriteLine("\n kainos: " + prices.iki.ToString() + " " + prices.rimi.ToString() + " " + prices.maxima.ToString());

                Item item1 = new Item();
                Item item2 = new Item();
                Item item3 = new Item();
                item1.Name = "MAKSIMA";
                item1.Price = prices.maxima;
                item2.Name = "RIMI";
                item2.Price = prices.rimi;
                item3.Name = "IKI";
                item3.Price = prices.iki;
                pricesList.Add(item1);
                pricesList.Add(item2);
                pricesList.Add(item3);


            return pricesList;
        }
        */
        public static List<Item> GetPricesByItem(string name)
        {
            var pricesList = new List<Item>();
            var client = new WebService.shopGuru_webService();
            var prices = client.GetPrices(name);
            if(prices.maxima + prices.rimi + prices.iki != 0)
            {
                Item item1 = new Item();
                Item item2 = new Item();
                Item item3 = new Item();
                item1.Name = "MAKSIMA";
                item1.Price = prices.maxima;
                item2.Name = "RIMI";
                item2.Price = prices.rimi;
                item3.Name = "IKI";
                item3.Price = prices.iki;
                pricesList.Add(item1);
                pricesList.Add(item2);
                pricesList.Add(item3);
            }

            return pricesList;
        }
    }
}