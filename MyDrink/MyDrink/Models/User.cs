using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDrink.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int _id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string phoneNunber { get; set; }
        public string address { get; set;  }
        public string email { get; set; }
    }
}
