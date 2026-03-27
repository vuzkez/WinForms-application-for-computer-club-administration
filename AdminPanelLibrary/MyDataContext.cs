using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public class MyDataContext : IDataContext
    {
        private readonly string connectionString;

        public MyDataContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataContext Create()
        {
            return new DataContext(connectionString);
        }
    }
}
