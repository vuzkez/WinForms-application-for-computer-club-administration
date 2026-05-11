using GameClub.DataAccess.RepositoryInterfaces;
using GameClub.Domain.Entities;
using GameClub.Domain.Enums;
using LinqToDB;
using LinqToDB.Async;
using LinqToDB.Data;

namespace GameClub.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для работы с тарифами (TariffSettings)
    /// </summary>
    public class TariffSettingRepository : ITariffSettingRepository
    {
        private readonly DataConnection db;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connection">Подключение к базе данных</param>
        public TariffSettingRepository(DataConnection connection)
        {
            db = connection;
        }

        /// <summary>
        /// Добавить новый тариф
        /// </summary>
        public async Task AddAsync(TariffSetting entity)
        {
            await db.InsertAsync(entity);
        }

        /// <summary>
        /// Обновить данные тарифа
        /// </summary>
        public async Task UpdateAsync(TariffSetting entity)
        {
            await db.UpdateAsync(entity);
        }

        /// <summary>
        /// Удалить тариф по идентификатору
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            await db.DeleteAsync(id);
        }

        /// <summary>
        /// Получить все тарифы
        /// </summary>
        /// <returns>Список тарифных настроек</returns>
        public async Task<List<TariffSetting>> GetAllAsync()
        {
            return await db.GetTable<TariffSetting>().ToListAsync();
        }

        /// <summary>
        /// Получить тариф по его типу
        /// </summary>
        /// <param name="tariff">Тип тарифа</param>
        /// <returns>Тариф или null</returns>
        public async Task<TariffSetting?> GetByTypeAsync(TariffType tariff)
        {
            return await db.GetTable<TariffSetting>()
                .FirstOrDefaultAsync(t => t.TypeValue == tariff.ToString());
        }

        /// <summary>
        /// Получить цену тарифа по его типу
        /// </summary>
        /// <param name="tariff">Тип тарифа</param>
        /// <returns>Цена за час</returns>
        public async Task<decimal> GetPriceAsync(TariffType tariff)
        {
            var setting = await db.GetTable<TariffSetting>()
                .FirstOrDefaultAsync(t => t.TypeValue == tariff.ToString());

            if (setting == null)
                throw new Exception($"Тариф {tariff} не найден!");

            return setting.PricePerHour;
        }

        /// <summary>
        /// Обновить цену тарифа по его типу
        /// </summary>
        /// <param name="tariff">Тип тарифа</param>
        /// <param name="newPrice">Новая цена за час</param>
        public async Task UpdatePriceAsync(TariffType tariff, decimal newPrice)
        {
            var setting = await db.GetTable<TariffSetting>()
                .FirstOrDefaultAsync(t => t.TypeValue == tariff.ToString());

            if (setting == null)
                throw new Exception($"Тариф {tariff} не найден!");

            setting.PricePerHour = newPrice;
            await db.UpdateAsync(setting);
        }

        /// <summary>
        /// Получить идентификатор тарифа по его типу
        /// </summary>
        /// <param name="tariff">Тип тарифа</param>
        /// <returns>Идентификатор тарифа</returns>
        public async Task<int> GetIdByTypeAsync(TariffType tariff)
        {
            var setting = await db.GetTable<TariffSetting>()
                .FirstOrDefaultAsync(s => s.TypeValue == tariff.ToString());

            if (setting == null)
                throw new Exception($"Тариф {tariff} не найден!");

            return setting.TariffId;
        }

        /// <summary>
        /// Получить тариф по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор тарифа</param>
        /// <returns>Тариф</returns>
        public async Task<TariffSetting> GetByIdAsync(int id)
        {
            var tariff = await db.GetTable<TariffSetting>()
                .FirstOrDefaultAsync(t => t.TariffId == id);

            if (tariff == null)
                throw new Exception($"Тариф по айди {id} не найден!");

            return tariff;
        }
    }
}