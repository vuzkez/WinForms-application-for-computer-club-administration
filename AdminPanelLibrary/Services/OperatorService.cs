using AdminPanelLibrary.Enums;
using AdminPanelLibrary.RepositoryInterfaces;

namespace AdminPanelLibrary.Entities
{
    public class OperatorService : IOperator
    {
        private readonly ISessionRepository _sessionRepo;
        private readonly ISeatRepository _seatRepo;
        private readonly ITariffSettingRepository _tariffRepo;

        public OperatorService(
            ISessionRepository sessionRepo,
            ISeatRepository seatRepo,
            ITariffSettingRepository tariffRepo)
        {
            _sessionRepo = sessionRepo;
            _seatRepo = seatRepo;
            _tariffRepo = tariffRepo;
        }

        public void OpenSession(int seatId, int userId, TariffType tariff, DateTime startTime, DateTime endTime)
        {
            var pricePerHour = _tariffRepo.GetPrice(tariff);
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

            _sessionRepo.Add(newSession);
            _seatRepo.UpdateStatus(seatId, SeatStatus.Busy);
        }

        public void CloseSession(int sessionId)
        {
            var session = _sessionRepo.GetAll().FirstOrDefault(p => p.SessionId == sessionId);

            if (session is null)
                throw new Exception($"Сессия {sessionId} не найдена");

            session.EndTime = DateTime.Now;
            _sessionRepo.Update(session);

            _seatRepo.UpdateStatus(session.SeatId, SeatStatus.Free);
        }

        public void AddHours(int sessionId, int hours)
        {
            var sessionDb = _sessionRepo.GetAll().FirstOrDefault(p => p.SessionId == sessionId);

            if (sessionDb is null)
                throw new Exception($"Сессия {sessionId} не найдена");

            var price = _tariffRepo.GetPrice(sessionDb.Tariff);

            sessionDb.EndTime = sessionDb.EndTime.AddHours(hours);
            sessionDb.TotalAmount += hours * price;

            _sessionRepo.Update(sessionDb);

            _seatRepo.UpdateStatus(sessionDb.SeatId, SeatStatus.Busy);
        }

        public List<Seat> FindFreeSeat(string roomType)
        {
            if (string.IsNullOrEmpty(roomType))
                return new List<Seat>();

            return _seatRepo.GetFreeSeatsByRoomType(roomType).ToList();
        }

        public List<Seat> GetAllSeatsWithStatus()
        {
            var seats = _seatRepo.GetAll().ToList();

            var activeSessions = _sessionRepo.GetActiveSessions()
                .ToDictionary(s => s.SeatId);

            foreach (var seat in seats)
            {
                var oldStatus = seat.Status;

                if (activeSessions.TryGetValue(seat.SeatId, out var session))
                {
                    var remaining = (session.EndTime - DateTime.Now).TotalMinutes;
                    seat.Status = remaining <= 15 ? SeatStatus.Expiring : SeatStatus.Busy;
                }
                else
                {
                    seat.Status = SeatStatus.Free;
                }

                if (seat.Status != oldStatus)
                    _seatRepo.Update(seat);
            }

            return seats;
        }

        public Session? GetActiveSessionBySeatId(int seatId)
        {
            return _sessionRepo.GetActiveSessionBySeatId(seatId);
        }
    }
}