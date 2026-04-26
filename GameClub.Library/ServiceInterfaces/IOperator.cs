using GameClub.Library.Entities;
using GameClub.Library.Enums;

namespace GameClub.Library
{
    public interface IOperator
    {
        Task OpenSessionAsync(int seatId, int userId, TariffType tariff,DateTime startTime,DateTime endTime);
        Task CloseSessionAsync(int sessionId);
        Task AddHoursAsync(int sessionId,int hours);
        Task<List<Seat>> FindFreeSeatAsync(string roomType);
        Task<List<Seat>> GetAllSeatsWithStatusAsync();
        Task<Session?> GetActiveSessionBySeatIdAsync(int seatId);
    }
}
