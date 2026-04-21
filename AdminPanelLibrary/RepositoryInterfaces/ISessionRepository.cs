using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelLibrary.Entities;

namespace AdminPanelLibrary.RepositoryInterfaces
{
    public interface ISessionRepository : IRepository<Session>
    {
        Session? GetActiveSessionBySeatId(int seatId);
        decimal GetTotalRevenue(DateTime from, DateTime to);
        IEnumerable<Session> GetActiveSessions();
    }
}
