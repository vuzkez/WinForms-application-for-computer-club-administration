using GameClub.DataAccess.RepositoryInterfaces;
using GameClub.Domain.Entities;
using GameClub.Domain.Enums;
using LinqToDB;
using LinqToDB.Async;
using LinqToDB.Data;

namespace GameClub.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для работы с местами
    /// </summary>
    public class SeatRepository : ISeatRepository
    {
        private readonly DataConnection db;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connection">Подключение к базе данных</param>
        public SeatRepository(DataConnection connection)
        {
            db = connection;
        }

        /// <summary>
        /// Добавить новое место
        /// </summary>
        public async Task AddAsync(Seat entity)
        {
            await db.InsertAsync(entity);
        }

        /// <summary>
        /// Обновить данные места
        /// </summary>
        public async Task UpdateAsync(Seat entity)
        {
            await db.UpdateAsync(entity);
        }

        /// <summary>
        /// Удалить место по идентификатору
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var seat = await db.GetTable<Seat>().FirstOrDefaultAsync(s => s.SeatId == id);
            if (seat != null)
                await db.DeleteAsync(seat);
        }

        /// <summary>
        /// Получить все места
        /// </summary>
        /// <returns>Список всех мест</returns>
        public async Task<List<Seat>> GetAllAsync()
        {
            return await db.GetTable<Seat>().ToListAsync();
        }

        /// <summary>
        /// Получить свободные места в зале указанного типа
        /// </summary>
        /// <param name="roomType">Тип зала</param>
        /// <returns>Список свободных мест</returns>
        public async Task<List<Seat>> GetFreeSeatsByRoomTypeAsync(string roomType)
        {
            return await db.GetTable<Seat>()
                .Where(s => s.SeatRoom == roomType && s.StatusValue == (int)SeatStatus.Free)
                .ToListAsync();
        }

        /// <summary>
        /// Обновить статус одного места
        /// </summary>
        /// <param name="seatId">Идентификатор места</param>
        /// <param name="seatStatus">Новый статус</param>
        public async Task UpdateStatusAsync(int seatId, SeatStatus seatStatus)
        {
            var seat = await db.GetTable<Seat>().FirstOrDefaultAsync(s => s.SeatId == seatId);

            if (seat == null)
                throw new Exception($"Место {seatId} не найдено!");

            seat.Status = seatStatus;
            await db.UpdateAsync(seat);
        }

        /// <summary>
        /// Пакетное обновление статусов нескольких мест
        /// </summary>
        /// <param name="seatIds">Список идентификаторов мест</param>
        /// <param name="newStatus">Новый статус</param>
        public async Task UpdateStatusBatchAsync(List<int> seatIds, SeatStatus newStatus)
        {
            if (seatIds == null || seatIds.Count == 0)
                return;

            await db.GetTable<Seat>()
                .Where(s => seatIds.Contains(s.SeatId))
                .Set(s => s.StatusValue, (int)newStatus)
                .UpdateAsync();
        }
    }
}