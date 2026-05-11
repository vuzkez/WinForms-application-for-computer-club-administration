using GameClub.DataAccess.RepositoryInterfaces;

namespace GameClub.DataAccess.UnitOfWork
{
    /// <summary>
    /// Единица работы: объединяет репозитории и управление транзакцией
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Репозиторий мест
        /// </summary>
        ISeatRepository Seats { get; }

        /// <summary>
        /// Репозиторий сессий
        /// </summary>
        ISessionRepository Sessions { get; }

        /// <summary>
        /// Репозиторий тарифов
        /// </summary>
        ITariffSettingRepository Tariffs { get; }

        /// <summary>
        /// Репозиторий пользователей
        /// </summary>
        IUserRepository Users { get; }

        /// <summary>
        /// Начать транзакцию
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Зафиксировать транзакцию
        /// </summary>
        void Commit();

        /// <summary>
        /// Откатить транзакцию
        /// </summary>
        void RollBack();
    }
}