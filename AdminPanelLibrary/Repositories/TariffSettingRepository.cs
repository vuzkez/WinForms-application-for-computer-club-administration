using AdminPanelLibrary.Entities;
using AdminPanelLibrary.Enums;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary.Repositories
{
    public class TariffSettingRepository : ITariffSettingRepository
    {
        private readonly IDataConnection dataConnection;

        public TariffSettingRepository(IDataConnection dataConnection)
        {
            this.dataConnection = dataConnection;
        }

        public void Add(TariffSetting entity)
        {
            using (var db = dataConnection.Create())
            {
                db.Insert(entity);
            }
        }

        public void Update(TariffSetting entity)
        {
            using (var db = dataConnection.Create())
            {
                db.Update(entity);
            }
        }

        public void Delete(int id)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<TariffSetting> GetAll()
        {
            using (var db = dataConnection.Create())
            {
                return db.GetTable<TariffSetting>().ToList();
            }
        }

        public TariffSetting? GetByType(TariffType tariff)
        {
            using (var db = dataConnection.Create()) 
            {
                return db.GetTable<TariffSetting>()
                    .FirstOrDefault(t => t.TypeValue == tariff.ToString());
            }
        }

        public decimal GetPrice(TariffType tariff)
        {
            using (var db = dataConnection.Create()) 
            {
                var setting = db.GetTable<TariffSetting>()
                    .FirstOrDefault(t => t.TypeValue == tariff.ToString());

                if (setting == null)
                    throw new Exception($"Тариф {tariff} не найден!");

                return setting.PricePerHour;
            }
        }

        public void UpdatePrice(TariffType tariff, decimal newPrice)
        {
            using (var db = dataConnection.Create()) 
            {
                var setting = db.GetTable<TariffSetting>()
                    .FirstOrDefault(t => t.TypeValue == tariff.ToString());

                if (setting == null)
                    throw new Exception($"Тариф {tariff} не найден!");

                setting.PricePerHour = newPrice;
                db.Update(setting);
            }
        }
    }
}
