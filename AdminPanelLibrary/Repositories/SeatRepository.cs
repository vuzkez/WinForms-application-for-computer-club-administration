using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelLibrary.Entities;
using AdminPanelLibrary.Enums;
using LinqToDB;
using static LinqToDB.Common.Configuration;

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

        public void Delete(int id)
        {
            using (var db = dataConnection.Create())
            {
                var seatForDelete = db.GetTable<Seat>().FirstOrDefault(s => s.SeatId == id);

                if (seatForDelete is null)
                    throw new Exception($"Место c айди {id} не найдено!");

                db.Delete(seatForDelete);
            }
        }

        public IEnumerable<Seat> GetAll()
        {
            using(var db = dataConnection.Create())
            {
                return db.GetTable<Seat>().ToList();
            }
        }

        public IEnumerable<Seat> GetFreeSeatsByRoomType(string roomType)
        {
            return GetAll().Where(s => s.SeatRoom == roomType && s.StatusValue == (int)SeatStatus.Free);
        }

        public void Update(Seat entity)
        {
            using (var db = dataConnection.Create())
            {
                db.Update(entity);
            }
        }

        public void UpdateStatus(int seatId, SeatStatus seatStatus)
        {
            var seatById = GetAll().FirstOrDefault(s => s.SeatId == seatId);

            if (seatById is null)
                throw new Exception($"Место {seatId} не найдено!");

            seatById.Status = seatStatus;
            Update(seatById);
        }
    }
}
