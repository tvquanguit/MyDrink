using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDrink.Models
{
    public class StateLogin
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public StateLogin()
        {
        }
    }
}
