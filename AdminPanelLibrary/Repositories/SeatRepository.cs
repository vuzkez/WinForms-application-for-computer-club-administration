using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelLibrary.Database;
using AdminPanelLibrary.Entities;
using AdminPanelLibrary.Enums;
using AdminPanelLibrary.RepositoryInterfaces;
using LinqToDB;

namespace AdminPanelLibrary.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly IDataConnection dataConnection;

        public SeatRepository(IDataConnection dataConnection)
        {
            this.dataConnection = dataConnection;
        }

        public void Add(Seat entity)
        {
            using (var db = dataConnection.Create())
            {
                db.Insert(entity);
            }
        }

        public void Update(Seat entity)
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
                var seat = db.GetTable<Seat>().FirstOrDefault(s => s.SeatId == id);
                if (seat != null)
                    db.Delete(seat);
            }
        }

        public IEnumerable<Seat> GetAll()
        {
            using (var db = dataConnection.Create())
            {
                return db.GetTable<Seat>().ToList();
            }
        }

        public IEnumerable<Seat> GetFreeSeatsByRoomType(string roomType)
        {
            using (var db = dataConnection.Create())
            {
                return db.GetTable<Seat>()
                    .Where(s => s.SeatRoom == roomType && s.StatusValue == (int)SeatStatus.Free)
                    .ToList();
            }
        }

        public void UpdateStatus(int seatId, SeatStatus seatStatus)
        {
            using (var db = dataConnection.Create()) 
            {
                var seat = db.GetTable<Seat>().FirstOrDefault(s => s.SeatId == seatId);

                if (seat == null)
                    throw new Exception($"Место {seatId} не найдено!");

                seat.Status = seatStatus;
                db.Update(seat);
            }
        }
    }
}
