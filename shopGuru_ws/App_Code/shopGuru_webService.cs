using System;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Net;
using System.Web.Services;
using System.Xml;
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
        using (SGEntities entities = new SGEntities())
        {
            
        }
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
