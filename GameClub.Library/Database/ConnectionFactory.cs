using LinqToDB;
using LinqToDB.Data;

namespace GameClub.Library.Database
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
                default:
                    throw new Exception($"Неизвестный провайдер: {providerName}");
            }

            return new DataConnection(options);
        }
    }
}
