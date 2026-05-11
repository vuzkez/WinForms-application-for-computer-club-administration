using GameClub.Domain.Entities;
using GameClub.Domain.Enums;

namespace GameClub.DataAccess.RepositoryInterfaces
{
    /// <summary>
    /// Репозиторий для работы с тарифами
    /// </summary>
    public interface ITariffSettingRepository : IRepository<TariffSetting>
    {
        /// <summary>
        /// Получить цену тарифа по его типу
        /// </summary>
        /// <param name="tariff">Тип тарифа</param>
        /// <returns>Цена за час</returns>
        Task<decimal> GetPriceAsync(TariffType tariff);

        /// <summary>
        /// Обновить цену тарифа по его типу
        /// </summary>
        /// <param name="tariff">Тип тарифа</param>
        /// <param name="newPrice">Новая цена за час</param>
        Task UpdatePriceAsync(TariffType tariff, decimal newPrice);

        /// <summary>
        /// Получить тариф по его типу
        /// </summary>
        /// <param name="tariff">Тип тарифа</param>
        /// <returns>Тариф или null</returns>
        Task<TariffSetting?> GetByTypeAsync(TariffType tariff);

        /// <summary>
        /// Получить идентификатор тарифа по его типу
        /// </summary>
        /// <param name="tariff">Тип тарифа</param>
        /// <returns>Идентификатор тарифа</returns>
        Task<int> GetIdByTypeAsync(TariffType tariff);

        /// <summary>
        /// Получить тариф по идентификатору
        /// </summary>
        /// <param name="tariffId">Идентификатор тарифа</param>
        /// <returns>Тариф</returns>
        Task<TariffSetting> GetByIdAsync(int tariffId);
    }
}