using GameClub.DataAccess.Database;

namespace GameClub.DataAccess.UnitOfWork
{
    /// <summary>
    /// Реализация фабрики единиц работы
    /// </summary>
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDataConnection _dataConnection;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dataConnection">Фабрика подключений к БД</param>
        public UnitOfWorkFactory(IDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }

        /// <summary>
        /// Создать новую единицу работы
        /// </summary>
        /// <returns>Объект UnitOfWorkLinq2db</returns>
        public IUnitOfWork Create()
        {
            return new UnitOfWorkLinq2db(_dataConnection);
        }
    }
}