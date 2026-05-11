using LinqToDB;
using LinqToDB.Data;

namespace GameClub.DataAccess.Database
{
    /// <summary>
    /// Фабрика подключений к базе данных
    /// </summary>
    public class ConnectionFactory : IDataConnection
    {
        private readonly string connectionString;
        private readonly string providerName;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connectionString">Строка подключения</param>
        /// <param name="providerName">Имя провайдера (sqlserver)</param>
        public ConnectionFactory(string connectionString, string providerName)
        {
            this.connectionString = connectionString;
            this.providerName = providerName;
        }

        /// <summary>
        /// Создать новое подключение к базе данных
        /// </summary>
        /// <returns>Объект DataConnection</returns>
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