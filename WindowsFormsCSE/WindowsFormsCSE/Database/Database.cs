using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;
using WindowsFormsCSE.Properties;

public class Database
{
    private static SqlConnection Connect()
    {
        try
        {
            var dbdoc = new XmlDocument();
            dbdoc.Load(Resources.DATABASE_PATH_dbLogin);

            var nodes = dbdoc.GetElementsByTagName(Resources.DATABASE_tagNameDatabase);
            foreach(XmlNode node in nodes)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = node.SelectSingleNode(Resources.DATABASE_xpathDataSource).InnerText;
                builder.UserID = node.SelectSingleNode(Resources.DATABASE_xpathUserID).InnerText;
                builder.Password = node.SelectSingleNode(Resources.DATABASE_xpathPassword).InnerText;
                builder.InitialCatalog = node.SelectSingleNode(Resources.DATABASE_xpathInitialCatalog).InnerText;
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
