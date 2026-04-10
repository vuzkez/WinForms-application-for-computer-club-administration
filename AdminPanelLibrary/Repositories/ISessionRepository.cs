using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary.Repositories
{
    public interface ISessionRepository : IRepository<Session>
    {
        Session? GetActiveSessionBySeatId(int seatId);
        decimal GetTotalRevenue(DateTime from, DateTime to);
        IEnumerable<Session> GetActiveSessions();
    }
}
