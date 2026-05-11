using GameClub.DataAccess.RepositoryInterfaces;
using GameClub.Domain.Entities;
using LinqToDB;
using LinqToDB.Async;
using LinqToDB.Data;

namespace GameClub.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сессиями (Sessions)
    /// </summary>
    public class SessionRepository : ISessionRepository
    {
        private readonly DataConnection db;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connection">Подключение к базе данных</param>
        public SessionRepository(DataConnection connection)
        {
            db = connection;
        }

        /// <summary>
        /// Добавить новую сессию
        /// </summary>
        public async Task AddAsync(Session entity)
        {
            await db.InsertAsync(entity);
        }

        /// <summary>
        /// Обновить данные сессии
        /// </summary>
        public async Task UpdateAsync(Session entity)
        {
            await db.UpdateAsync(entity);
        }

        /// <summary>
        /// Удалить сессию по идентификатору
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var session = await db.GetTable<Session>().FirstOrDefaultAsync(s => s.SessionId == id);
            if (session != null)
                await db.DeleteAsync(session);
        }

        /// <summary>
        /// Получить все сессии
        /// </summary>
        /// <returns>Список всех сессий</returns>
        public async Task<List<Session>> GetAllAsync()
        {
            return await db.GetTable<Session>().ToListAsync();
        }

        /// <summary>
        /// Получить активную сессию по идентификатору места
        /// </summary>
        /// <param name="seatId">Идентификатор места</param>
        /// <returns>Активная сессия или null</returns>
        public async Task<Session?> GetActiveSessionBySeatIdAsync(int seatId)
        {
            return await db.GetTable<Session>()
                .FirstOrDefaultAsync(s => s.SeatId == seatId && s.EndTime > DateTime.Now);
        }

        /// <summary>
        /// Получить все активные сессии
        /// </summary>
        /// <returns>Список активных сессий</returns>
        public async Task<List<Session>> GetActiveSessionsAsync()
        {
            return await db.GetTable<Session>()
                .Where(s => s.EndTime > DateTime.Now)
                .ToListAsync();
        }

        /// <summary>
        /// Получить общую выручку за заданный период
        /// </summary>
        /// <param name="from">Начальная дата</param>
        /// <param name="to">Конечная дата (включительно)</param>
        /// <returns>Сумма выручки</returns>
        public async Task<decimal> GetTotalRevenueAsync(DateTime from, DateTime to)
        {
            return await db.GetTable<Session>()
                .Where(s => s.EndTime >= from && s.EndTime <= to)
                .SumAsync(s => s.TotalAmount);
        }

        /// <summary>
        /// Получить сессию по идентификатору
        /// </summary>
        /// <param name="sessionId">Идентификатор сессии</param>
        /// <returns>Сессия или null</returns>
        public async Task<Session?> GetByIdAsync(int sessionId)
        {
            return await db.GetTable<Session>()
                .FirstOrDefaultAsync(s => s.SessionId == sessionId);
        }

        /// <summary>
        /// Получить активную сессию по месту с подгрузкой связанных сущностей
        /// </summary>
        /// <param name="seatId">Идентификатор места</param>
        /// <returns>Сессия с Seat, User и TariffSetting или null</returns>
        public async Task<Session?> GetActiveSessionBySeatIdWithDetailsAsync(int seatId)
        {
            return await db.GetTable<Session>()
                .Where(s => s.SeatId == seatId && s.EndTime > DateTime.Now)
                .LoadWith(s => s.Seat)
                .LoadWith(s => s.User)
                .LoadWith(s => s.TariffSetting)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Получить сессию по идентификатору с подгрузкой тарифа
        /// </summary>
        /// <param name="sessionId">Идентификатор сессии</param>
        /// <returns>Сессия с TariffSetting или null</returns>
        public async Task<Session?> GetByIdWithDetailsAsync(int sessionId)
        {
            return await db.GetTable<Session>()
                .Where(s => s.SessionId == sessionId)
                .LoadWith(s => s.TariffSetting)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Получить все активные сессии с подгрузкой связанных сущностей
        /// </summary>
        /// <returns>Список активных сессий с Seat, User и TariffSetting</returns>
        public async Task<List<Session>> GetActiveSessionsWithDetailsAsync()
        {
            return await db.GetTable<Session>()
                .Where(s => s.EndTime > DateTime.Now)
                .LoadWith(s => s.Seat)
                .LoadWith(s => s.User)
                .LoadWith(s => s.TariffSetting)
                .ToListAsync();
        }
    }
}