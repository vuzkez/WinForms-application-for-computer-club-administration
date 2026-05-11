using GameClub.DataAccess.Database;
using GameClub.DataAccess.Repositories;
using GameClub.DataAccess.RepositoryInterfaces;
using LinqToDB.Data;

namespace GameClub.DataAccess.UnitOfWork
{
    /// <summary>
    /// Реализация единицы работы через LinqToDB: управление транзакцией и доступ к репозиториям
    /// </summary>
    public class UnitOfWorkLinq2db : IUnitOfWork
    {
        /// <summary>
        /// Подключение и флаги
        /// </summary>
        private readonly DataConnection connection;
        private bool disposed;
        private bool hasActiveTransaction;

        /// <summary>
        /// Репозиторий мест
        /// </summary>
        public ISeatRepository Seats { get; }

        /// <summary>
        /// Репозиторий сессий
        /// </summary>
        public ISessionRepository Sessions { get; }

        /// <summary>
        /// Репозиторий тарифов
        /// </summary>
        public ITariffSettingRepository Tariffs { get; }

        /// <summary>
        /// Репозиторий пользователей
        /// </summary>
        public IUserRepository Users { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dataConnection">Фабрика подключений к БД</param>
        public UnitOfWorkLinq2db(IDataConnection dataConnection)
        {
            connection = dataConnection.Create();

            Seats = new SeatRepository(connection);
            Sessions = new SessionRepository(connection);
            Tariffs = new TariffSettingRepository(connection);
            Users = new UserRepository(connection);
        }

        /// <summary>
        /// Начать транзакцию, если ещё не начата
        /// </summary>
        public void BeginTransaction()
        {
            if (!hasActiveTransaction)
            {
                connection.BeginTransaction();
                hasActiveTransaction = true;
            }
        }

        /// <summary>
        /// Зафиксировать транзакцию
        /// </summary>
        public void Commit()
        {
            if (hasActiveTransaction)
            {
                connection.CommitTransaction();
                hasActiveTransaction = false;
            }
        }

        /// <summary>
        /// Откатить транзакцию
        /// </summary>
        public void RollBack()
        {
            if (hasActiveTransaction)
            {
                connection.RollbackTransaction();
                hasActiveTransaction = false;
            }
        }

        /// <summary>
        /// Освободить подключение
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                connection?.Dispose();
                disposed = true;
            }
        }
    }
}