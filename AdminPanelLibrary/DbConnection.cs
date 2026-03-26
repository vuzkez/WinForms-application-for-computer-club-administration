using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public static class DbConnection
    {
        public static string connectionString = @"Data Source=VUZKEZ\SQLEXPRESS;Initial Catalog=GameClub;Integrated Security=True";

        public static DataContext GetConnection()
        {
            return new DataContext(connectionString);
        }
    }
}
