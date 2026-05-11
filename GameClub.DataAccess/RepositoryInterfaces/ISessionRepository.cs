using GameClub.Domain.Entities;

namespace GameClub.DataAccess.RepositoryInterfaces
{
    /// <summary>
    /// Репозиторий для работы с сессиями
    /// </summary>
    public interface ISessionRepository : IRepository<Session>
    {
        /// <summary>
        /// Получить активную сессию по идентификатору места
        /// </summary>
        /// <param name="seatId">Идентификатор места</param>
        /// <returns>Активная сессия или null</returns>
        Task<Session?> GetActiveSessionBySeatIdAsync(int seatId);

        /// <summary>
        /// Получить общую выручку за заданный период
        /// </summary>
        /// <param name="from">Начальная дата</param>
        /// <param name="to">Конечная дата (включительно)</param>
        /// <returns>Сумма выручки</returns>
        Task<decimal> GetTotalRevenueAsync(DateTime from, DateTime to);

        /// <summary>
        /// Получить все активные сессии
        /// </summary>
        /// <returns>Список активных сессий</returns>
        Task<List<Session>> GetActiveSessionsAsync();

        /// <summary>
        /// Получить сессию по идентификатору
        /// </summary>
        /// <param name="sessionId">Идентификатор сессии</param>
        /// <returns>Сессия или null</returns>
        Task<Session?> GetByIdAsync(int sessionId);

        /// <summary>
        /// Получить все активные сессии с подгрузкой связанных сущностей
        /// </summary>
        /// <returns>Список активных сессий с Seat, User и TariffSetting</returns>
        Task<List<Session>> GetActiveSessionsWithDetailsAsync();

        /// <summary>
        /// Получить активную сессию по месту с подгрузкой связанных сущностей
        /// </summary>
        /// <param name="seatId">Идентификатор места</param>
        /// <returns>Сессия с Seat, User и TariffSetting или null</returns>
        Task<Session?> GetActiveSessionBySeatIdWithDetailsAsync(int seatId);

        /// <summary>
        /// Получить сессию по идентификатору с подгрузкой тарифа
        /// </summary>
        /// <param name="sessionId">Идентификатор сессии</param>
        /// <returns>Сессия с TariffSetting или null</returns>
        Task<Session?> GetByIdWithDetailsAsync(int sessionId);
    }
}