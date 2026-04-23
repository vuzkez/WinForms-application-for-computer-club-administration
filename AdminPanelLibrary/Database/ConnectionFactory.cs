using LinqToDB;
using LinqToDB.Data;

namespace AdminPanelLibrary.Database
{
    public class ConnectionFactory : IDataConnection
    {
        private readonly string connectionString;
        private readonly string providerName;

        public ConnectionFactory(string connectionString,string providerName)
        {
            this.connectionString = connectionString;
            this.providerName = providerName;
        }

        public DataConnection Create()
        {
            DataOptions options;

            switch (providerName.ToLower())
            {
                case "sqlserver":
                    options = new DataOptions().UseSqlServer(connectionString);
                    break;
                case "postgresql":
                    options = new DataOptions().UsePostgreSQL(connectionString);
                    break;
                case "mysql":
                    options = new DataOptions().UseMySql(connectionString);
                    break;
                case "sqlite":
                    options = new DataOptions().UseSQLite(connectionString);
                    break;
                default:
                    throw new Exception($"Неизвестный провайдер: {providerName}");
            }

            return new DataConnection(options);
        }
    }
}
