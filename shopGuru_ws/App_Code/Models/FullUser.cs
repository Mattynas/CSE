using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shopGuru_ws.Models;

/// <summary>
/// Summary description for FullUser
/// </summary>
public struct FullUser
{
    public string username;
    public string password;

    public string email;
    public string number;

    public int items_uploaded;
    public int receipts_uploaded;
    public int lottery_uploaded;

    public static FullUser GetUser(string username)
    {
        FullUser user;
        using(SGEntities context = new SGEntities())
        {
            try
            {
                var userClass = (from u in context.Users
                where u.username == username
                select u).Single();

                user.username = userClass.username;
                user.password = userClass.password;

                user.email = userClass.User_info1.email;
                user.number = userClass.User_info1.phone_number;

                user.items_uploaded = userClass.User_statistics1.items_uploaded;
                user.receipts_uploaded = userClass.User_statistics1.receipts_uploaded;
                user.lottery_uploaded = userClass.User_statistics1.lottery_uploaded;
            }
            catch (Exception)
            {
                user.username = "";
                user.password = "";

                user.email = "";
                user.number = "";

                user.items_uploaded = 0;
                user.receipts_uploaded = 0;
                user.lottery_uploaded = 0;
            }
        }
        return user;
    }
}