using AdminPanelLibrary.Enums;
using AdminPanelLibrary.Repositories;
using LinqToDB;

namespace AdminPanelLibrary.Entities
{
    public class Operator : IOperator
    {
        private readonly IDataConnection dataContext;

        public Operator(IDataConnection dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddHours(int sessionId, int hours)
        {
            using (var db = dataContext.Create())
            {
                var sessionDb = db.GetTable<Session>().FirstOrDefault(p => p.SessionId == sessionId);

                if (sessionDb is null)
                    throw new Exception($"Сессия {sessionId} не найдена");
                
                var trafficSetting = db.GetTable<TariffSetting>()
                      .FirstOrDefault(t => t.TypeValue == sessionDb.Tariff.ToString());
                if (trafficSetting == null)
                {
                    throw new Exception($"Таблица тарифа {sessionDb.Tariff} не найдена");
                }
                var price = trafficSetting.PricePerHour;

                sessionDb.EndTime = sessionDb.EndTime.AddHours(hours);
                sessionDb.TotalAmount += hours * price;

                var seat = db.GetTable<Seat>().FirstOrDefault(p => p.SeatId == sessionDb.SeatId);

                if (seat == null)
                    throw new Exception($"Место {sessionDb.SeatId} не найдено");

                if (seat.Status == SeatStatus.Expiring)
                    seat.Status = SeatStatus.Busy;

                db.Update(sessionDb);
                db.Update(seat);
            }
        }

        public void CloseSession(int sessionId)
        {
            using (var db = dataContext.Create())
            {
                var session = db.GetTable<Session>().FirstOrDefault(p => p.SessionId == sessionId);
                
                if (session is null)
                    throw new Exception($"Сессия {sessionId} не найдена");

                session.EndTime = DateTime.Now;
                var seat = db.GetTable<Seat>().FirstOrDefault(s => s.SeatId == session.SeatId);

                if (seat is null)
                    throw new Exception($"Место {session.SeatId} не найдено");

                seat.Status = SeatStatus.Free;
                db.Update(session);
                db.Update(seat);
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
                var tariffSetting = db.GetTable<TariffSetting>().FirstOrDefault(p => p.TypeValue == tariff.ToString());

                if (tariffSetting is null)
                    throw new Exception($"Тарифная сетка {tariff} не найдена!");

                var pricePerHour = tariffSetting.PricePerHour;
                newClient.TotalAmount = pricePerHour * hours;
                db.Insert(newClient);

                var seat = db.GetTable<Seat>().FirstOrDefault(s => s.SeatId == seatId);

                if (seat is null)
                    throw new Exception($"Место {seatId} не найдено!");

                seat.Status = SeatStatus.Busy;
                db.Update(seat);
            }
        }

        public List<Seat> FindFreeSeat(string roomType)
        {
            if (string.IsNullOrEmpty(roomType)) 
                return new List<Seat>();

            using (var db = dataContext.Create())
            {
                var freeSeats = db.GetTable<Seat>()
                    .Where(s => s.SeatRoom == roomType && s.StatusValue == (int)SeatStatus.Free).ToList();
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
                    var oldStatus = seat.Status;

                    if (activeSessions.TryGetValue(seat.SeatId,out var session))
                    {
                        var remaining = (session.EndTime - DateTime.Now).TotalMinutes;
                        seat.Status = remaining <= 15 ? SeatStatus.Expiring : SeatStatus.Busy;
                    }
                    else
                    {
                        seat.Status = SeatStatus.Free;
                    }

                    if (seat.Status != oldStatus)
                        db.Update(seat);
                }
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
