using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml;
/// <summary>
/// Summary description for shopGuru_webService
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
        //return true;
        if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(username))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Users.xml");

            var root = doc.DocumentElement;
            foreach(XmlElement elem in root.GetElementsByTagName("user"))
            {
                if (elem.GetAttribute("username") == username && elem.GetAttribute("password") == password) return true;
            }
        }
        return false;
    }

    [WebMethod]
    public string FillLotteryForm(NameValueCollection formData)
    {
        string url = "https://kvituzaidimas.vmi.lt/";
        System.Uri uri = new Uri(url);

        using (WebClient client = new WebClient())
        {
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            byte[] result = client.UploadValues(uri, "POST", formData);

            var responseString = Encoding.UTF8.GetString(result);
            return responseString;
        }
    }

}
