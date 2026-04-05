using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public class DataContextSingleton : IDataContext
    {
        private static DataContextSingleton instance;
        private readonly string connectionString;
        private DataContext dataContext;

        private DataContextSingleton(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public static DataContextSingleton GetInstance(string connectionString)
        {
            if (instance == null)
                instance = new DataContextSingleton(connectionString);
            return instance;
        }

        public DataContext Create()
        {
            return new DataContext(connectionString);
        }
    }
}
