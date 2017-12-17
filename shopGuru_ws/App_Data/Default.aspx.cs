using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using shopGuru_ws.Models;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["SGEntities"].ConnectionString;

        conn.Open();
        SqlDataAdapter adapter = new SqlDataAdapter("select username, receipts_uploaded from account.Users join account.User_statistics on account.Users.user_statistics=account.user_statistics.id order by receipts_uploaded desc", conn);

        DataTable table = new DataTable("MostActiveUsers");
        adapter.Fill(table);

        conn.Close();

        UserTable.DataSource = table;
        UserTable.DataBind();
    }
}