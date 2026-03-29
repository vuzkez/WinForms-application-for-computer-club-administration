using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public interface IOperator
    {
        void OpenSession(int seatId, int userId, TariffType tariff,DateTime startTime,DateTime endTime);
        void CloseSession(int sessionId);
        void AddHours(int sessionId,int hours);
        Seat? FindFreeSeat(string roomType);
        List<Seat> GetAllSeatsWithStatus();
        Session? GetActiveSessionBySeatId(int seatId);
    }
}
