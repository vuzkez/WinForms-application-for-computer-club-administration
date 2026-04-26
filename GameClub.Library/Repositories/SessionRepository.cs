using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.Library.Database;
using GameClub.Library.Entities;
using GameClub.Library.RepositoryInterfaces;
using LinqToDB;
using LinqToDB.Async;
using LinqToDB.Data;

namespace GameClub.Library.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly DataConnection db;

        public SessionRepository(DataConnection connection)
        {
            db = connection;
        }

        public async Task AddAsync(Session entity)
        {
            await db.InsertAsync(entity);
        }

        public async Task UpdateAsync(Session entity)
        {
             await db.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var session = await db.GetTable<Session>().FirstOrDefaultAsync(s => s.SessionId == id);
            if (session != null)
                await db.DeleteAsync(session);
        }

        public async Task<List<Session>> GetAllAsync()
        {
             return await db.GetTable<Session>().ToListAsync();
        }

        public async Task<Session?> GetActiveSessionBySeatIdAsync(int seatId)
        {
            return await db.GetTable<Session>()
                .FirstOrDefaultAsync(s => s.SeatId == seatId && s.EndTime > DateTime.Now);
        }

        public async Task<List<Session>> GetActiveSessionsAsync()
        {
            return await db.GetTable<Session>()
                .Where(s => s.EndTime > DateTime.Now).ToListAsync(); 
        }

        public async Task<decimal> GetTotalRevenueAsync(DateTime from, DateTime to)
        {
            return await db.GetTable<Session>()
                .Where(s => s.EndTime >= from && s.EndTime <= to)
                .SumAsync(s => s.TotalAmount); 
        }
        public async Task<Session?> GetByIdAsync(int sessionId)
        {
            return await db.GetTable<Session>()
                .FirstOrDefaultAsync(s => s.SessionId == sessionId);
        }
    }
}
