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
                
                var price = db.GetTable<TariffSetting>()
                      .First(t => t.TypeValue == sessionDb.Tariff.ToString())
                      .PricePerHour;

                sessionDb.EndTime = sessionDb.EndTime.AddHours(hours);
                sessionDb.TotalAmount += hours * price;

                var seat = db.GetTable<Seat>().First(p => p.SeatId == sessionDb.SeatId);
                if (seat.Status == SeatStatus.Expiring)
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

        public Seat? FindFreeSeat(string roomType)
        {
            using (var db = dataContext.Create())
            {
                var freeSeats = db.GetTable<Seat>()
                    .Where(s => !db.GetTable<Session>()
                    .Any(session => session.SeatId == s.SeatId && session.EndTime > DateTime.Now));

                if (!string.IsNullOrEmpty(roomType))
                {
                    string translation = string.Empty;
                    switch (roomType.ToLower())
                    {
                        case "общий":
                            translation = "General";
                            break;
                        case "вип":
                            translation = "Vip";
                            break;
                    }
                    return freeSeats.FirstOrDefault(s => s.SeatRoom.ToLower() == roomType.ToLower()
                    || s.SeatRoom.ToLower() == translation.ToLower());
                }
                
                return freeSeats.FirstOrDefault();
            }
        }

        public List<Seat> GetAllSeatsWithStatus()
        {
            using (var db = dataContext.Create())
            {
                var seats = db.GetTable<Seat>().ToList();
                var activeSeassions = db.GetTable<Session>()
                    .Where(s => s.EndTime > DateTime.Now)
                    .ToDictionary(s => s.SeatId);

                foreach (var seat in seats)
                {
                    if (activeSeassions.TryGetValue(seat.SeatId,out var session))
                    {
                        var remaining = (session.EndTime - DateTime.Now).TotalMinutes;
                        seat.Status = remaining <= 15 ? SeatStatus.Expiring : SeatStatus.Busy;
                    }
                    else
                    {
                        seat.Status = SeatStatus.Free;
                    }
                }
                return seats;
            }
        }
    }
}
