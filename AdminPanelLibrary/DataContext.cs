using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public class DataContext : IDataContext
    {
        private readonly string connectionString;

        public DataContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataContext Create()
        {
            return new DataContext(connectionString);
        }
    }
}
