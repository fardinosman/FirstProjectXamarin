using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FirstProjectXamarin.Data
{
    public interface ISQLLite
    {
        SQLiteConnection GetConnection(); 
    }
}
