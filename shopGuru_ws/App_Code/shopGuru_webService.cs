using System;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Net;
using System.Web.Services;
using System.Linq;
using shopGuru_ws.Models;

/// <summary>
/// It is a web service for ShopGuru app
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

    [WebMethod]
    public bool Login(string username, string password)
    {
        using (SGEntities context = new SGEntities())
        {
           return (from u in context.Users
                       where u.username == username
                       && u.password == password
                       select u).Any<User>();
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
                user_info.user_statistics = user_statistics.id;
                context.User_info.Add(user_info);

                User user = new User(username, password);
                user.user_info = user_info.id;
                context.Users.Add(user);

                context.SaveChanges();
                result = true;
            }
            catch (Exception) { } 
        }
        return result;
    }

    [WebMethod]
    public string FillLotteryForm(byte[] bytes)
    {
        string url = "https://kvituzaidimas.vmi.lt/api/register/";
        try
        {
            using(WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var results = wc.UploadData(url, "POST", bytes);
                return "all good";
            }

        }
        catch (WebException ex)
        {
            string exString = "";
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
            {
                exString = reader.ReadToEnd();
                return exString;
            }
        }
    }

}
