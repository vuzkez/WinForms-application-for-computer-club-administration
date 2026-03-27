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
                var tariffSettings = db.GetTable<TariffSetting>().FirstOrDefault(t => t.Type == tariff);
                if (tariffSettings != null)
                {
                    tariffSettings.PricePerHour = newPrice;
                    db.SubmitChanges();
                }
            }
        }

        public decimal GetRevenue(DateTime from, DateTime to)
        {
            decimal revenue = 0;
            using (var db = dataContext.Create())
            {
                var sessionsList = db.GetTable<Session>().Where(t => t.EndTime >= from && t.EndTime <= to).ToList();

                foreach (var t in sessionsList)
                {
                    revenue += t.TotalAmount;
                }
            }
            return revenue;
        }
    }
}
