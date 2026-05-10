using GameClub.Domain.Entities;
using GameClub.Domain.Enums;

namespace GameClub.BusinessLogic.ServiceInterfaces
{
    public interface IOperator
    {
        Task OpenSessionAsync(int seatId, int userId, TariffType tariff,DateTime startTime,DateTime endTime);
        Task CloseSessionAsync(int sessionId);
        Task AddHoursAsync(int sessionId,int hours);
        Task<List<Seat>> FindFreeSeatsAsync(string roomType);
        Task<List<Seat>> FindActiveSeatsAsync();
        Task<List<Seat>> GetAllSeatsWithStatusAsync();
        Task<Session?> GetActiveSessionBySeatIdAsync(int seatId);
        Task<List<TariffSetting>> GetAllTariffsAsync();
        Task<List<Session>> GetActiveSessionsWithDetailsAsync();
    }
}

