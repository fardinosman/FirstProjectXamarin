using System;
using System.Collections.Generic;
using System.Text;
using FirstProjectXamarin.Models;
using SQLite;
using Xamarin.Forms;

namespace FirstProjectXamarin.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();
        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLLite>().GetConnection();
            database.CreateTable<User>();



        }

        public User GetUser()
        {
            lock (locker)
            {
                if (database.Table<User>().Count() ==0)
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().First();
                }
            }
        }

        public int SaveUser(User user)
        {
            lock(locker)
            {
                if (user.Id!=0)
                {
                    database.Update(user);
                    return user.Id;
                }
                else
                {
                   return database.Insert(user);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock(locker)
            {
                return database.Delete<User>(id);
            }
        }

    }
}
