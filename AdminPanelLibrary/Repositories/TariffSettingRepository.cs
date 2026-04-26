using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelLibrary.Database;
using AdminPanelLibrary.Entities;
using AdminPanelLibrary.Enums;
using AdminPanelLibrary.RepositoryInterfaces;
using LinqToDB;
using LinqToDB.Async;
using LinqToDB.Data;

namespace AdminPanelLibrary.Repositories
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
            throw new NotSupportedException();
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
    }
}
