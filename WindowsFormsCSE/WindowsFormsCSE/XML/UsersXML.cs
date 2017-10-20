using System;
using System.Xml.Linq;
using WindowsFormsCSE.Properties;

namespace WindowsFormsCSE.XML
{
    enum Attributes { username, password, email }

    class UsersXML
    {
        //---------------------Path----------------------
        private static string pathToUsers = Resources.USERS_PATH_Users;
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
                    return false;
                }
                catch (System.IO.FileNotFoundException e)
                {
                    return false;
                }

                if (CheckAttribute(username, Attributes.username, root) && CheckAttribute(password, Attributes.password, root)) return true;
            }
            return false;
        }

        public static bool Register(string username, string password, string email)
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
                root = new XElement(Resources.USERS_elementUsers);
                xdoc.Add(root);
            }
            catch (System.IO.FileNotFoundException e)
            {
                xdoc = new XDocument();
                root = new XElement(Resources.USERS_elementUsers);
                xdoc.Add(root);
            }

            XElement element = new XElement(Resources.USERS_elementUser);
            XAttribute attribute = new XAttribute(Resources.USERS_attributeUsername, username);

            element.Add(attribute);
            attribute = new XAttribute(Resources.USERS_attributePassword, password);

            element.Add(attribute);
            attribute = new XAttribute(Resources.USERS_attributeEmail, email);

            element.Add(attribute);
            root.Add(element);
            xdoc.Save(pathToUsers);
            return true;
        }


        public static bool CheckAttribute(string value, Attributes attribute, XElement root)
        {
            foreach (XElement element in root.Descendants(Resources.USERS_elementUser))
            {
                if (element.Attribute(Enum.GetName(typeof(Attributes), attribute)).Value == value) return true;
            }
            return false;
        }

    }
}
