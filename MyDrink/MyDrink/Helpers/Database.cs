using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using MyDrink.Models;
namespace MyDrink.Helpers
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDatabase()
        {
            try
            {
                //tạo csdl
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "MyDrink.db")))
                {
                    connection.CreateTable<StateLogin>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                //
                return false;
            }
        }
        public StateLogin GetStateLogin()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "MyDrink.db")))
                {
                    var data = (from statelogin in connection.Table<StateLogin>() select statelogin).ToList();
                    return data.ToList().FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
        public bool InsertStateLogin(StateLogin data)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "MyDrink.db")))
                {
                    connection.Insert(data);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {

                return false;
            }
        }
        public bool DeleteStateLogin()
        {
            try 
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "MyDrink.db")))
                {
                    connection.DropTable<StateLogin>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
    }

}
