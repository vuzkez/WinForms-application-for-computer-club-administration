using GameClub.Domain.Entities;
using GameClub.Domain.Enums;

namespace GameClub.DataAccess.RepositoryInterfaces
{
    /// <summary>
    /// Репозиторий для работы с местами
    /// </summary>
    public interface ISeatRepository : IRepository<Seat>
    {
        /// <summary>
        /// Получить свободные места в зале указанного типа
        /// </summary>
        /// <param name="roomType">Тип зала</param>
        /// <returns>Список свободных мест</returns>
        Task<List<Seat>> GetFreeSeatsByRoomTypeAsync(string roomType);

        /// <summary>
        /// Обновить статус одного места
        /// </summary>
        /// <param name="seatId">Идентификатор места</param>
        /// <param name="seatStatus">Новый статус</param>
        Task UpdateStatusAsync(int seatId, SeatStatus seatStatus);

        /// <summary>
        /// Пакетное обновление статусов нескольких мест
        /// </summary>
        /// <param name="seatIds">Список идентификаторов мест</param>
        /// <param name="newStatus">Новый статус</param>
        Task UpdateStatusBatchAsync(List<int> seatIds, SeatStatus newStatus);
    }
}