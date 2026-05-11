using GameClub.Domain.Entities;
using GameClub.Domain.Enums;

namespace GameClub.BusinessLogic.ServiceInterfaces
{
    /// <summary>
    /// Сервис административных операций
    /// </summary>
    public interface IAdministrator
    {
        /// <summary>
        /// Получить общую выручку за заданный период
        /// </summary>
        /// <param name="from">Начальная дата периода</param>
        /// <param name="to">Конечная дата периода (включительно)</param>
        /// <returns>Сумма выручки за период</returns>
        Task<decimal> GetRevenueAsync(DateTime from, DateTime to);

        /// <summary>
        /// Изменить цену указанного тарифа
        /// </summary>
        /// <param name="tariff">Тип тарифа</param>
        /// <param name="newPrice">Новая цена за час</param>
        Task ConfigureTariffAsync(TariffType tariff, decimal newPrice);

        /// <summary>
        /// Получить текущую цену тарифа по его типу
        /// </summary>
        /// <param name="tariff">Тип тарифа</param>
        /// <returns>Цена за час</returns>
        Task<decimal> GetTariffPriceAsync(TariffType tariff);

        /// <summary>
        /// Получить список всех операторов
        /// </summary>
        /// <returns>Список пользователей с ролью Operator</returns>
        Task<List<User>> GetAllOperatorsAsync();

        /// <summary>
        /// Удалить оператора по идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя-оператора</param>
        Task DeleteOperatorAsync(int userId);

        /// <summary>
        /// Добавить нового оператора
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="fullName">Полное имя</param>
        Task AddOperatorAsync(string login, string password, string fullName);

        /// <summary>
        /// Обновить данные существующего оператора
        /// </summary>
        /// <param name="user">Объект пользователя с обновлёнными полями</param>
        Task UpdateOperatorAsync(User user);
    }
}