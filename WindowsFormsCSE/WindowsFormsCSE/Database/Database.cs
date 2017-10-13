using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;

public class Database
{
    private static SqlConnection Connect()
    {
        try
        {
            var dbdoc = new XmlDocument();
            dbdoc.Load("../Database/DatabaseLogin.xml");

            var nodes = dbdoc.GetElementsByTagName("Database");
            foreach(XmlNode node in nodes)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = node.SelectSingleNode("DataSource").InnerText;
                builder.UserID = node.SelectSingleNode("UserID").InnerText;
                builder.Password = node.SelectSingleNode("Password").InnerText;
                builder.InitialCatalog = node.SelectSingleNode("InitialCatalog").InnerText;
                return new SqlConnection(builder.ConnectionString);
            }
            return null;

        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
            return null;
        }
        catch(XmlException e)
        {
            Console.WriteLine(e.ToString());
            return null;
        }

    }

    public static List<string> Query(String query)
    {
        try
        {
            SqlConnection connection = Connect();
            if (connection != null)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                List<string> stringList = new List<string>();
                while (reader.Read())
                {
                    stringList.Add(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
                return stringList;
                
            }
            else
            {
                return null;
            }
        }

        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
            return null;
        }
    }
}
