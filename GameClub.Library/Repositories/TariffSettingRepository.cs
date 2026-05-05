using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.Library.Database;
using GameClub.Library.Entities;
using GameClub.Library.Enums;
using GameClub.Library.RepositoryInterfaces;
using LinqToDB;
using LinqToDB.Async;
using LinqToDB.Data;

namespace GameClub.Library.Repositories
{
    public class TariffSettingRepository : ITariffSettingRepository
    {
        private readonly DataConnection db;

        public TariffSettingRepository(DataConnection connection)
        {
            db = connection;
        }

        public async Task AddAsync(TariffSetting entity)
        {
            await db.InsertAsync(entity);
        }

        public async Task UpdateAsync(TariffSetting entity)
        {
             await db.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await db.DeleteAsync(id);
        }

        public async Task<List<TariffSetting>> GetAllAsync()
        {
            return await db.GetTable<TariffSetting>().ToListAsync();
        }

        public async Task<TariffSetting?> GetByTypeAsync(TariffType tariff)
        {
            return await db.GetTable<TariffSetting>()
                .FirstOrDefaultAsync(t => t.TypeValue == tariff.ToString());
        }

        public async Task<decimal> GetPriceAsync(TariffType tariff)
        {
            var setting = await db.GetTable<TariffSetting>()
                .FirstOrDefaultAsync(t => t.TypeValue == tariff.ToString());

            if (setting == null)
                throw new Exception($"Тариф {tariff} не найден!");

            return setting.PricePerHour;
        }

        public async Task UpdatePriceAsync(TariffType tariff, decimal newPrice)
        {
            var setting = await db.GetTable<TariffSetting>()
                .FirstOrDefaultAsync(t => t.TypeValue == tariff.ToString());

            if (setting == null)
                throw new Exception($"Тариф {tariff} не найден!");

            setting.PricePerHour = newPrice;
            await db.UpdateAsync(setting);
        }

        public async Task<int> GetIdByTypeAsync(TariffType tariff)
        {
            var setting = await db.GetTable<TariffSetting>().FirstOrDefaultAsync(s => s.TypeValue == tariff.ToString());

            if (setting == null)
                throw new Exception($"Тариф {tariff} не найден!");

            return setting.TariffId;
        }

        public async Task<TariffSetting> GetByIdAsync(int id)
        {
            var tariff = await db.GetTable<TariffSetting>().FirstOrDefaultAsync(t => t.TariffId == id);

            if (tariff == null)
                throw new Exception($"Тариф по айди {id} не найден!");

            return tariff;
        }
    }
}
