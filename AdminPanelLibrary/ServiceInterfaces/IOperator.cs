using AdminPanelLibrary.Entities;
using AdminPanelLibrary.Enums;

namespace AdminPanelLibrary
{
    public interface IOperator
    {
        void OpenSession(int seatId, int userId, TariffType tariff,DateTime startTime,DateTime endTime);
        void CloseSession(int sessionId);
        void AddHours(int sessionId,int hours);
        List<Seat> FindFreeSeat(string roomType);
        List<Seat> GetAllSeatsWithStatus();
        Session? GetActiveSessionBySeatId(int seatId);
    }
}
