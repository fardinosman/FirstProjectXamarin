using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProjectXamarin.Models
{
   public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public User()
        {

        }
        public bool CheckInformation()
        {
            if (!this.Username.Equals("")&&!this.Password.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
