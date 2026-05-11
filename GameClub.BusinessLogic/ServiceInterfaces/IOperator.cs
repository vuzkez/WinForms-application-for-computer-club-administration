using GameClub.Domain.Entities;
using GameClub.Domain.Enums;

namespace GameClub.BusinessLogic.ServiceInterfaces
{
    /// <summary>
    /// Сервис операционных действий
    /// </summary>
    public interface IOperator
    {
        /// <summary>
        /// Открыть новую сессию на указанном месте
        /// </summary>
        /// <param name="seatId">Идентификатор места</param>
        /// <param name="userId">Идентификатор оператора, открывающего сессию</param>
        /// <param name="tariff">Тип тарифа</param>
        /// <param name="startTime">Время начала сессии</param>
        /// <param name="endTime">Время окончания сессии</param>
        Task OpenSessionAsync(int seatId, int userId, TariffType tariff, DateTime startTime, DateTime endTime);

        /// <summary>
        /// Закрыть активную сессию по её идентификатору
        /// </summary>
        /// <param name="sessionId">Идентификатор сессии</param>
        Task CloseSessionAsync(int sessionId);

        /// <summary>
        /// Добавить часы к активной сессии
        /// </summary>
        /// <param name="sessionId">Идентификатор сессии</param>
        /// <param name="hours">Количество добавляемых часов</param>
        Task AddHoursAsync(int sessionId, int hours);

        /// <summary>
        /// Найти свободные места в зале указанного типа
        /// </summary>
        /// <param name="roomType">Тип зала</param>
        /// <returns>Список свободных мест</returns>
        Task<List<Seat>> FindFreeSeatsAsync(string roomType);

        /// <summary>
        /// Найти все места, на которых прямо сейчас идёт активная сессия
        /// </summary>
        /// <returns>Список занятых мест</returns>
        Task<List<Seat>> FindActiveSeatsAsync();

        /// <summary>
        /// Получить все места с актуальным статусом
        /// </summary>
        /// <returns>Список всех мест</returns>
        Task<List<Seat>> GetAllSeatsWithStatusAsync();

        /// <summary>
        /// Получить активную сессию по идентификатору места
        /// </summary>
        /// <param name="seatId">Идентификатор места</param>
        /// <returns>Активная сессия или null</returns>
        Task<Session?> GetActiveSessionBySeatIdAsync(int seatId);

        /// <summary>
        /// Получить все тарифы
        /// </summary>
        /// <returns>Список тарифных настроек</returns>
        Task<List<TariffSetting>> GetAllTariffsAsync();

        /// <summary>
        /// Получить все активные сессии с подгруженными связанными сущностями
        /// </summary>
        /// <returns>Список активных сессий с Seat, User и TariffSetting</returns>
        Task<List<Session>> GetActiveSessionsWithDetailsAsync();
    }
}