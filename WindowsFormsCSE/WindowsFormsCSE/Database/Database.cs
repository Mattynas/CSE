using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;



public class MYSQLServer
{
    private static SqlConnection Connect()
    {
        try
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "personal-cse.database.windows.net";
            builder.UserID = "labutis";
            builder.Password = "123!@#ASD";
            builder.InitialCatalog = "cse";

            return new SqlConnection(builder.ConnectionString);
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
            return null;
        }

    }

    public static List <string> Query(String query)
    {
        try
        {
            var connection = Connect();
            if(connection != null)
            {
                using (connection)
                {
                    /*
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT *");
                    sb.Append("FROM users");
                    String sql = sb.ToString();
                    */

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> stringList = new List<string>();
                            int i = 0;
                            while (reader.Read())
                            {
                                stringList.Add(reader.GetValue(0).ToString());
                            }
                            reader.Close();
                            return stringList;
                        }
                    }
                }
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
