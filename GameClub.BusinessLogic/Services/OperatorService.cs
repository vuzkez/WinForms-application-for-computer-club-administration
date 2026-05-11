using GameClub.BusinessLogic.ServiceInterfaces;
using GameClub.Domain.Enums;
using GameClub.DataAccess.UnitOfWork;
using GameClub.Domain.Entities;

namespace GameClub.BusinessLogic.Services
{
    /// <summary>
    /// Реализация операционных действий: управление сессиями, поиск мест, работа с тарифами
    /// </summary>
    public class OperatorService : IOperator
    {
        private readonly IUnitOfWorkFactory uowFactory;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="uowFactory">Фабрика единиц работы</param>
        public OperatorService(IUnitOfWorkFactory uowFactory)
        {
            this.uowFactory = uowFactory;
        }

        /// <summary>
        /// Открыть новую сессию на указанном месте
        /// </summary>
        public async Task OpenSessionAsync(int seatId, int userId, TariffType tariff, DateTime startTime, DateTime endTime)
        {
            using (var uow = uowFactory.Create())
            {
                var pricePerHour = await uow.Tariffs.GetPriceAsync(tariff);
                var tariffId = await uow.Tariffs.GetIdByTypeAsync(tariff);
                int hours = (int)(endTime - startTime).TotalHours;

                uow.BeginTransaction();
                try
                {
                    await uow.Sessions.AddAsync(new Session()
                    {
                        TariffId = tariffId,
                        UserId = userId,
                        SeatId = seatId,
                        StartTime = startTime,
                        EndTime = endTime,
                        TotalAmount = pricePerHour * hours
                    });
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

        /// <summary>
        /// Закрыть активную сессию по её идентификатору
        /// </summary>
        public async Task CloseSessionAsync(int sessionId)
        {
            using (var uow = uowFactory.Create())
            {
                var session = await uow.Sessions.GetByIdAsync(sessionId);

                if (session is null)
                    throw new Exception($"Сессия {sessionId} не найдена");

                session.EndTime = DateTime.Now.AddSeconds(-1);
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

        /// <summary>
        /// Добавить часы к активной сессии
        /// </summary>
        public async Task AddHoursAsync(int sessionId, int hours)
        {
            using (var uow = uowFactory.Create())
            {
                var sessionById = await uow.Sessions.GetByIdWithDetailsAsync(sessionId);

                if (sessionById == null)
                    throw new Exception($"Сессия по id: {sessionId} не найдена!");

                sessionById.EndTime = sessionById.EndTime.AddHours(hours);
                sessionById.TotalAmount += hours * sessionById.TariffSetting.PricePerHour;

                uow.BeginTransaction();
                try
                {
                    await uow.Sessions.UpdateAsync(sessionById);
                    await uow.Seats.UpdateStatusAsync(sessionById.SeatId, SeatStatus.Busy);
                    uow.Commit();
                }
                catch
                {
                    uow.RollBack();
                    throw;
                }
            }
        }

        /// <summary>
        /// Найти свободные места в зале указанного типа
        /// </summary>
        public async Task<List<Seat>> FindFreeSeatsAsync(string roomType)
        {
            using (var uow = uowFactory.Create())
            {
                if (string.IsNullOrEmpty(roomType))
                    return new List<Seat>();

                return await uow.Seats.GetFreeSeatsByRoomTypeAsync(roomType);
            }
        }

        /// <summary>
        /// Получить все места с актуальным статусом
        /// </summary>
        public async Task<List<Seat>> GetAllSeatsWithStatusAsync()
        {
            using (var uow = uowFactory.Create())
            {
                var seats = await uow.Seats.GetAllAsync();
                var activeSessions = await uow.Sessions.GetActiveSessionsAsync();

                var statusChanges = new Dictionary<SeatStatus, List<int>>();

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
                        if (!statusChanges.ContainsKey(seat.Status))
                            statusChanges[seat.Status] = new List<int>();

                        statusChanges[seat.Status].Add(seat.SeatId);
                    }
                }

                uow.BeginTransaction();
                try
                {
                    foreach (var kvp in statusChanges)
                    {
                        var newStatus = kvp.Key;
                        var seatIds = kvp.Value;

                        await uow.Seats.UpdateStatusBatchAsync(seatIds, newStatus);
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

        /// <summary>
        /// Получить активную сессию по идентификатору места
        /// </summary>
        public async Task<Session?> GetActiveSessionBySeatIdAsync(int seatId)
        {
            using (var uow = uowFactory.Create())
            {
                return await uow.Sessions.GetActiveSessionBySeatIdAsync(seatId);
            }
        }

        /// <summary>
        /// Найти все места, на которых прямо сейчас идёт активная сессия
        /// </summary>
        public async Task<List<Seat>> FindActiveSeatsAsync()
        {
            using (var uow = uowFactory.Create())
            {
                var activeSessions = await uow.Sessions.GetActiveSessionsWithDetailsAsync();

                return activeSessions
                    .Where(s => s.Seat != null)
                    .Select(s => s.Seat)
                    .Distinct()
                    .ToList();
            }
        }

        /// <summary>
        /// Получить все тарифы
        /// </summary>
        public async Task<List<TariffSetting>> GetAllTariffsAsync()
        {
            using (var uow = uowFactory.Create())
            {
                return await uow.Tariffs.GetAllAsync();
            }
        }

        /// <summary>
        /// Получить все активные сессии с подгруженными связанными сущностями
        /// </summary>
        public async Task<List<Session>> GetActiveSessionsWithDetailsAsync()
        {
            using (var uow = uowFactory.Create())
            {
                return await uow.Sessions.GetActiveSessionsWithDetailsAsync();
            }
        }
    }
}