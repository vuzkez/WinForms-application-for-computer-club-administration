using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public class Admin : IAdministrator
    {
        private readonly IDataContext dataContext;

        public Admin(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void ConfigureTariff(TariffType tariff, decimal newPrice)
        {
            using (var db = dataContext.Create())
            {
                var tariffSettings = db.GetTable<TariffSetting>().FirstOrDefault(t => t.TypeValue == tariff.ToString());
                if (tariffSettings != null)
                {
                    tariffSettings.PricePerHour = newPrice;
                    db.SubmitChanges();
                }
            }
        }

        public decimal GetRevenue(DateTime from, DateTime to)
        {
            using (var db = dataContext.Create())
            {
                return db.GetTable<Session>()
                    .Where(s => s.EndTime >= from && s.EndTime <= to)
                    .Sum(s => s.TotalAmount);
            }
        }

        public decimal GetTariffPrice(TariffType tariff)
        {
            using (var db = dataContext.Create())
            {
                var setting = db.GetTable<TariffSetting>()
                    .FirstOrDefault(t => t.TypeValue == tariff.ToString());

                return setting?.PricePerHour ?? 0;
            }
        }
    }
}
