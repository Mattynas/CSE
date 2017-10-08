using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsCSE.Users
{
    enum Attributes {username, password, email}

    static class UsersFile
    {
        //---------------------Path----------------------
        private static string pathToUser = "..//..//users.xml";
        //-----------------------------------------------

        public static bool Login(string username, string password)
        {
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(username))
            {
                XDocument xdoc;
                XElement root;

                try
                {
                    xdoc = XDocument.Load(pathToUser);
                    root = xdoc.Root;
                }
                catch (Exception e)
                {
                    return false;
                }

                if (CheckAttribute(username, Attributes.username, root) && CheckAttribute(password, Attributes.password, root)) return true;
            }
            return false;
        }

        public static bool Register(string username, string password, string email)
        {
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(email))
            {
                XDocument xdoc;
                XElement root;

                try
                {
                    xdoc = XDocument.Load(pathToUser);
                    root = xdoc.Root;
                    if (CheckAttribute(username, Attributes.username, root) || CheckAttribute(email, Attributes.email, root)) return false;
                }
                catch (Exception e)
                {
                    xdoc = new XDocument();
                    root = new XElement("Users");
                    xdoc.Add(root);
                }

                XElement element = new XElement("User");
                XAttribute attribute = new XAttribute("username", username);

                element.Add(attribute);
                attribute = new XAttribute("password", password);

                element.Add(attribute);
                attribute = new XAttribute("email", email);

                element.Add(attribute);
                root.Add(element);
                xdoc.Save(pathToUser);
                return true;   
            }
            return false;
        }


        public static bool CheckAttribute(string value, Attributes attribute, XElement root)
        {
            foreach(XElement element in root.Descendants("User"))
            {
                if (element.Attribute(Enum.GetName(typeof(Attributes), attribute)).Value == value) return true;
            }
            return false;
        }

        //Delete

        //GetFullList

        //Admin
    }
}
