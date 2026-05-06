using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.Library.Entities;

namespace GameClub.Library.RepositoryInterfaces
{
    public interface ISessionRepository : IRepository<Session>
    {
        Task<Session?> GetActiveSessionBySeatIdAsync(int seatId);
        Task<decimal> GetTotalRevenueAsync(DateTime from, DateTime to);
        Task<List<Session>> GetActiveSessionsAsync();
        Task<Session?> GetByIdAsync(int sessionId);
        Task<List<Session>> GetActiveSessionsWithDetailsAsync();
        Task<Session?> GetActiveSessionBySeatIdWithDetailsAsync(int seatId);
        Task<Session?> GetByIdWithDetailsAsync(int sessionId);
    }
}
