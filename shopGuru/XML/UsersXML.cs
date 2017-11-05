using System;
using System.Linq;
using System.Xml.Linq;
using shopGuru.Properties;

namespace shopGuru.XML
{
    public enum Attributes { username, password, email }

    public class UsersXML
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
                catch (System.Xml.XmlException)
                {
                    return false;
                }
                catch (System.IO.FileNotFoundException)
                {
                    return false;
                }

                var temp =
                    from element in root.Descendants(Resources.USERS_elementUser)
                    where element.Attribute(Enum.GetName(typeof(Attributes), (int) 0)).Value == username
                    where element.Attribute(Enum.GetName(typeof(Attributes), (int) 1)).Value == password
                    select element;

                return temp.Any();
                
            }
            return false;
        }

        public static bool Register(string username, string password, string email, bool isAdmin = false)
        {

            XDocument xdoc;
            XElement root;

            try
            {
                xdoc = XDocument.Load(pathToUsers);
                root = xdoc.Root;
                if (CheckAttribute(username, Attributes.username, root) || CheckAttribute(email, Attributes.email, root)) return false;
            }
            catch (System.Xml.XmlException)
            {
                xdoc = new XDocument();
                root = new XElement(Resources.USERS_elementUsers);
                xdoc.Add(root);
            }
            catch (System.IO.FileNotFoundException)
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
            var temp =
                from element in root.Descendants(Resources.USERS_elementUser)
                where element.Attribute(Enum.GetName(typeof(Attributes), attribute)).Value == value
                select element;

            return temp.Any();
        }

    }
}
