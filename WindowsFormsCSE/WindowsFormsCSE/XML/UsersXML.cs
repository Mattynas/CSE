using System;
using System.Xml.Linq;

namespace WindowsFormsCSE.XML
{
    enum Attributes { username, password, email }

    class UsersXML
    {
        //---------------------Path----------------------
        private static string pathToUsers = "XML/users.xml";
        //-----------------------------------------------

        public static bool Login(string username, string password)
        {
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(username))
            {
                XDocument xdoc;
                XElement root;

                try
                {
                    xdoc = XDocument.Load(pathToUsers);
                    root = xdoc.Root;
                }
                catch (System.Xml.XmlException e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
                catch (System.IO.FileNotFoundException e)
                {
                    Console.WriteLine(e.ToString());
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
                    xdoc = XDocument.Load(pathToUsers);
                    root = xdoc.Root;
                    if (CheckAttribute(username, Attributes.username, root) || CheckAttribute(email, Attributes.email, root)) return false;
                }
                catch (System.Xml.XmlException e)
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
                xdoc.Save(pathToUsers);
                return true;
            }
            return false;
        }


        public static bool CheckAttribute(string value, Attributes attribute, XElement root)
        {
            foreach (XElement element in root.Descendants("User"))
            {
                if (element.Attribute(Enum.GetName(typeof(Attributes), attribute)).Value == value) return true;
            }
            return false;
        }

    }
}
