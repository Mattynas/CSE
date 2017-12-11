using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Platform.XamarinAndroid;
using SQLite;
using shopGuru_android.interfaces;
using shopGuru_android.Model;
using System.Threading.Tasks;

namespace shopGuru_android.database
{
    public class SQLiteManager
    {
        private string _databasePath;
        private SQLiteAsyncConnection db;

        public async Task<string> CreateDatabaseAsync(string path)
        {
            try
            {

                var connection = new SQLiteAsyncConnection(path);
                await connection.CreateTableAsync<Item>();
                _databasePath = path;
                db = connection;
                return "database created";

            }
            catch(SQLiteException ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> InsertUpdateDataAsync(Item item)
        {
            try
            {
                var b = await db.InsertAsync(item);
                if (b != 0)
                {
                    await db.UpdateAsync(item);
                }
                    return "inserted or updated database";
            }
            catch(SQLiteException ex)
            {
                return ex.Message;
            } 
        }
        public async Task<List<Item>> GetItemListAsync()
        {
            return await db.QueryAsync<Item>("SELECT * FROM [Item]");
        }
        public async Task<int> DeleteItemAsync(Item item)
        {
            return await db.DeleteAsync(item);
        }


    }
}