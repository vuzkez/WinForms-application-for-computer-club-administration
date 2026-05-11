using LinqToDB.Data;

namespace GameClub.DataAccess.Database
{
    /// <summary>
    /// Фабрика подключений к базе данных
    /// </summary>
    public interface IDataConnection
    {
        /// <summary>
        /// Создать новое подключение
        /// </summary>
        /// <returns>Объект DataConnection</returns>
        DataConnection Create();
    }
}