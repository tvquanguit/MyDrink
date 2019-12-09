using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDrink.Interfaces
{
    public interface ISQLiteInterface
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
