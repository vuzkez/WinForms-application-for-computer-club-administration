using AdminPanelLibrary.Database;
using AdminPanelLibrary.Entities;
using AdminPanelLibrary.RepositoryInterfaces;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly IDataConnection dataConnection;

        public SessionRepository(IDataConnection dataConnection)
        {
            this.dataConnection = dataConnection;
        }

        public void Add(Session entity)
        {
            using (var db = dataConnection.Create())
            {
                db.Insert(entity);
            }
        }

        public void Update(Session entity)
        {
            using (var db = dataConnection.Create())
            {
                db.Update(entity);
            }
        }

        public void Delete(int id)
        {
            using (var db = dataConnection.Create())
            {
                var session = db.GetTable<Session>().FirstOrDefault(s => s.SessionId == id);
                if (session != null)
                    db.Delete(session);
            }
        }

        public IEnumerable<Session> GetAll()
        {
            using (var db = dataConnection.Create())
            {
                return db.GetTable<Session>().ToList();
            }
        }

        public Session? GetActiveSessionBySeatId(int seatId)
        {
            using (var db = dataConnection.Create()) 
            {
                return db.GetTable<Session>()
                    .FirstOrDefault(s => s.SeatId == seatId && s.EndTime > DateTime.Now);
            }
        }

        public IEnumerable<Session> GetActiveSessions()
        {
            using (var db = dataConnection.Create()) 
            {
                return db.GetTable<Session>()
                    .Where(s => s.EndTime > DateTime.Now)
                    .ToList(); 
            }
        }

        public decimal GetTotalRevenue(DateTime from, DateTime to)
        {
            using (var db = dataConnection.Create())  
            {
                return db.GetTable<Session>()
                    .Where(s => s.EndTime >= from && s.EndTime <= to)
                    .Sum(s => s.TotalAmount); 
            }
        }
    }
}
