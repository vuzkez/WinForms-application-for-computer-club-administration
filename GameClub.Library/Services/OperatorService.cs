using GameClub.Library.Database;
using GameClub.Library.Enums;
using GameClub.Library.UnitOfWork;
using LinqToDB.Async;

namespace GameClub.Library.Entities
{
    public class OperatorService : IOperator
    {
        private readonly IUnitOfWorkFactory uowFactory;

        public OperatorService(IUnitOfWorkFactory uowFactory)
        {
            this.uowFactory = uowFactory;
        }

        public async Task OpenSessionAsync(int seatId, int userId, TariffType tariff, DateTime startTime, DateTime endTime)
        {
            using (var uow = uowFactory.Create())
            {
                var pricePerHour = await uow.Tariffs.GetPriceAsync(tariff);
                int hours = (int)(endTime - startTime).TotalHours;

                var newSession = new Session
                {
                    Tariff = tariff,
                    UserId = userId,
                    SeatId = seatId,
                    StartTime = startTime,
                    EndTime = endTime,
                    TotalAmount = pricePerHour * hours
                };

                uow.BeginTransaction();
                try
                {
                    await uow.Sessions.AddAsync(newSession);
                    await uow.Seats.UpdateStatusAsync(seatId, SeatStatus.Busy);
                    uow.Commit();
                }
                catch
                {
                    uow.RollBack();
                    throw;
                }
            }
        }

        public async Task CloseSessionAsync(int sessionId)
        {
            using (var uow = uowFactory.Create())
            {
                var session = await uow.Sessions.GetByIdAsync(sessionId);

                if (session is null)
                    throw new Exception($"Сессия {sessionId} не найдена");

                session.EndTime = DateTime.Now;
                uow.BeginTransaction();
                try
                {
                    await uow.Sessions.UpdateAsync(session);
                    await uow.Seats.UpdateStatusAsync(session.SeatId, SeatStatus.Free);
                    uow.Commit();
                }
                catch
                {
                    uow.RollBack(); 
                    throw;
                }
            }
        }

        public async Task AddHoursAsync(int sessionId, int hours)
        {
            using (var uow = uowFactory.Create())
            {
                var sessionDb = await uow.Sessions.GetByIdAsync(sessionId);

                if (sessionDb is null)
                    throw new Exception($"Сессия {sessionId} не найдена");

                var price = await uow.Tariffs.GetPriceAsync(sessionDb.Tariff);

                sessionDb.EndTime = sessionDb.EndTime.AddHours(hours);
                sessionDb.TotalAmount += hours * price;

                uow.BeginTransaction();
                try
                {
                    await uow.Sessions.UpdateAsync(sessionDb);
                    await uow.Seats.UpdateStatusAsync(sessionDb.SeatId, SeatStatus.Busy);
                    uow.Commit();
                }
                catch
                {
                    uow.RollBack();
                    throw;
                }
            }
        }

        public async Task<List<Seat>> FindFreeSeatsAsync(string roomType)
        {
            using (var uow = uowFactory.Create())
            {
                if (string.IsNullOrEmpty(roomType))
                    return new List<Seat>();

                return await uow.Seats.GetFreeSeatsByRoomTypeAsync(roomType);
            }
        }

        public async Task<List<Seat>> GetAllSeatsWithStatusAsync()
        {
            using (var uow = uowFactory.Create())
            {
                var seats = await uow.Seats.GetAllAsync();
                var activeSessions = await uow.Sessions.GetActiveSessionsAsync();

                uow.BeginTransaction();
                try
                {
                    foreach (var seat in seats)
                    {
                        var oldStatus = seat.Status;
                        var activeSession = activeSessions.FirstOrDefault(s => s.SeatId == seat.SeatId);

                        if (activeSession != null)
                        {
                            var remaining = (activeSession.EndTime - DateTime.Now).TotalMinutes;
                            seat.Status = remaining <= 15 ? SeatStatus.Expiring : SeatStatus.Busy;
                        }
                        else
                        {
                            seat.Status = SeatStatus.Free;
                        }

                        if (seat.Status != oldStatus)
                        {
                            await uow.Seats.UpdateAsync(seat);
                        }

                    }
                    uow.Commit();
                }
                catch
                {
                    uow.RollBack();
                    throw;
                }

                return seats;
            }
        }

        public async Task<Session?> GetActiveSessionBySeatIdAsync(int seatId)
        {
            using (var uow = uowFactory.Create())
            {
                return await uow.Sessions.GetActiveSessionBySeatIdAsync(seatId);
            }
        }

        public async Task<List<Seat>> FindActiveSeatsAsync()
        {
            using (var uow = uowFactory.Create())
            {
                var seats = await uow.Seats.GetAllAsync();
                var activeSessions = await uow.Sessions.GetActiveSessionsAsync();

                if (activeSessions.Count == 0)
                    return new List<Seat>();

                return seats.Where(seat => activeSessions.Any(session => session.SeatId == seat.SeatId)).ToList();
            }
        }
    }
}