using System;
using System.IO;
using System.Net;
using System.Web.Services;
using System.Linq;
using shopGuru_ws.Models;
using System.Collections.Generic;

/// <summary>
/// Web service for ShopGuru app
/// </summary>
//[WebService(Namespace = "http://shopguruwebservice.azurewebsites.net/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class shopGuru_webService : System.Web.Services.WebService
{
    public shopGuru_webService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //User methods
    [WebMethod]
    public bool Login(string username, string password)
    {
        using (SGEntities context = new SGEntities())
        {
            try
            {
                return (from u in context.Users
                where u.username == username
                && u.password == password
                select u).Any();
            }
            catch (Exception)
            {
                return false;
            }

        }
    }

    [WebMethod]
    public bool Register(string username, string password, string email, string number)
    {
        bool result = false;
        using (SGEntities context = new SGEntities())
        {
            try
            {
                User_statistics user_statistics = new User_statistics();
                context.User_statistics.Add(user_statistics);

                User_info user_info = new User_info(email, number);
                context.User_info.Add(user_info);

                User user = new User(username, password);
                user.user_info = user_info.id;
                user.user_statistics = user_statistics.id;
                context.Users.Add(user);

                context.SaveChanges();
                result = true;
            }
            catch (Exception) { }
        }
        return result;
    }

    [WebMethod]
    public string GetPhoneNumber(string username)
    {
        using (SGEntities context = new SGEntities())
        {
            try
            {
                var number = (from u in context.Users
                              join i in context.User_info
                              on u.user_info equals i.id
                              where u.username == username
                              select i.phone_number).Single();
                return number;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }

    [WebMethod]
    public string GetEmail(string username)
    {
        using (SGEntities context = new SGEntities())
        {
            try
            {
                var number = (from u in context.Users
                              join i in context.User_info
                              on u.user_info equals i.id
                              where u.username == username
                              select i.email).Single();
                return number;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }

    [WebMethod]
    public FullUser GetUser(string name)
    {
        return FullUser.GetUser(name);
    }


    //Items methods
    [WebMethod]
    public decimal GetPrice(string name, string shop)
    {
        using (SGEntities context = new SGEntities())
        {
            try
            {
                var items = context.Items;
                var prices = context.Prices;
                var result = from i in items
                             join p in prices
                             on i.id equals p.item
                             where p.shop == shop
                             select p.price1;
                return result.Single<decimal>();
            }
            catch (Exception)
            {
                return -1;
            }

        }
    }

    [WebMethod]
    public ItemPrice GetPrices(string label)
    {
        ItemPrice item = new ItemPrice();
        //return ItemPrice.GetItem(label);
        using (SGEntities context = new SGEntities())
        {
            
            Item itemkl = new Item();
            LevenshteinComparer comp = new LevenshteinComparer();
            foreach(var i in context.Items)
            {
                if (comp.LevenshteinAlgorithm(label.ToLower(), i.label.ToLower(), 5))
                {
                    itemkl = i;
                    break;
                }
            }

                item.name = itemkl.label;
                if (itemkl.weightable.HasValue) item.weightable = itemkl.weightable.Value;
                else item.weightable = false;

            var prices = from p in context.Prices
                         where p.item == itemkl.id
                         select p;


                foreach(var p in prices)
                {
                    if (p.shop == "Maxima") item.maxima = p.price1;
                    if (p.shop == "Iki") item.iki = p.price1;
                    if (p.shop == "Rimi") item.rimi = p.price1;
                }
            
   
        }
        return item;
    }

    [WebMethod]
    public HashSet<ItemPrice> CompareItemList(List<ItemPrice> list, int precision)
    {
        IListComparer comparer = new LevenshteinComparer();
        var result = comparer.CompareList(list, precision);
        return result;
    }


    [WebMethod]
    public string FillLotteryForm(byte[] bytes)
    {
        string url = "https://kvituzaidimas.vmi.lt/api/register/";
        try
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var results = wc.UploadData(url, "POST", bytes);
                return "Registration successful";
            }

        }
        catch (WebException ex)
        {
            string exString = "";
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
            {
                exString = reader.ReadToEnd();
                if (exString.Contains("duplicate"))
                {
                    return "The receipt has been registered already";
                }
                else if (exString.Contains("datetime"))
                {
                    return "Date Format error";
                }
                else
                {
                    return exString;
                }
            }
        }
    }
}
