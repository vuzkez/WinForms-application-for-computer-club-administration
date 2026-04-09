using LinqToDB.Data;
using LinqToDB;

namespace AdminPanelLibrary
{
    public class SqlServerConnectionFactory : IDataConnection
    {
        private static SqlServerConnectionFactory instance;
        private readonly string connectionString;

        private SqlServerConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public static SqlServerConnectionFactory GetInstance(string connectionString)
        {
            if (instance == null)
                instance = new SqlServerConnectionFactory(connectionString);
            return instance;
        }

        public DataConnection Create()
        {
            return new DataConnection(new DataOptions().UseSqlServer(connectionString));
        }
    }
}
