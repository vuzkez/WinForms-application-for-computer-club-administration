using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace AdminPanelLibrary
{
    public class Operator : IOperator
    {
        private readonly IDataContext dataContext;

        public Operator(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddHours(int sessionId, int hours)
        {
            using (var db = dataContext.Create())
            {
                var sessionDb = db.GetTable<Session>().First(p => p.SessionId == sessionId);
                
                var trafficSettiong = db.GetTable<TariffSetting>()
                      .FirstOrDefault(t => t.TypeValue == sessionDb.Tariff.ToString());
                if (trafficSettiong == null)
                {
                    throw new Exception("Таблица тарифа не найдена");
                }
                var price = trafficSettiong.PricePerHour;

                sessionDb.EndTime = sessionDb.EndTime.AddHours(hours);
                sessionDb.TotalAmount += hours * price;

                var seat = db.GetTable<Seat>().FirstOrDefault(p => p.SeatId == sessionDb.SeatId);
                if (seat == null)
                {
                    throw new Exception("Место не найдено");
                }
                else if (seat.Status == SeatStatus.Expiring)
                {
                    seat.Status = SeatStatus.Busy;
                }

                db.SubmitChanges();
            }
        }

        public void CloseSession(int sessionId)
        {
            using (var db = dataContext.Create())
            {
                var session = db.GetTable<Session>().First(p => p.SessionId == sessionId);
                session.EndTime = DateTime.Now;
                var seat = db.GetTable<Seat>().First(s => s.SeatId == session.SeatId);
                seat.Status = SeatStatus.Free;
                db.SubmitChanges();
            }
        }

        public void OpenSession(int seatId, int userId, TariffType tariff, DateTime startTime, DateTime endTime)
        {
            var newClient = new Session();
            newClient.Tariff = tariff;
            newClient.UserId = userId;
            newClient.SeatId = seatId;
            newClient.StartTime = startTime;
            newClient.EndTime = endTime;

            int hours = (int)(endTime - startTime).TotalHours;

            using (var db = dataContext.Create())
            {
                var pricePerHour = db.GetTable<TariffSetting>().First(p => p.TypeValue == tariff.ToString()).PricePerHour;
                newClient.TotalAmount = pricePerHour * hours;
                db.GetTable<Session>().InsertOnSubmit(newClient);
                var seat = db.GetTable<Seat>().First(s => s.SeatId == seatId);
                seat.Status = SeatStatus.Busy;
                db.SubmitChanges();
            }
        }

        public List<Seat> FindFreeSeat(string roomType)
        {
            if (string.IsNullOrEmpty(roomType)) 
                return new List<Seat>();

            using (var db = dataContext.Create())
            {
                var freeSeats = db.GetTable<Seat>()
                    .Where(s => s.SeatRoom == roomType && s.Status == SeatStatus.Free).ToList();
                return freeSeats;
            }
        }

        public List<Seat> GetAllSeatsWithStatus()
        {
            using (var db = dataContext.Create())
            {
                var seats = db.GetTable<Seat>().ToList();
                var activeSessions = db.GetTable<Session>()
                    .Where(s => s.EndTime > DateTime.Now)
                    .ToDictionary(s => s.SeatId);

                foreach (var seat in seats)
                {
                    if (activeSessions.TryGetValue(seat.SeatId,out var session))
                    {
                        var remaining = (session.EndTime - DateTime.Now).TotalMinutes;
                        seat.Status = remaining <= 15 ? SeatStatus.Expiring : SeatStatus.Busy;
                    }
                    else
                    {
                        seat.Status = SeatStatus.Free;
                    }
                }
                db.SubmitChanges();
                return seats;
            }
        }

        public Session? GetActiveSessionBySeatId(int seatId)
        {
            using (var db = dataContext.Create())
            {
                return db.GetTable<Session>()
                    .FirstOrDefault(s => s.SeatId == seatId && s.EndTime > DateTime.Now);
            }
        }
    }
}
