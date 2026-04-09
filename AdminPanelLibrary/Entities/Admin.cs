using LinqToDB;

namespace AdminPanelLibrary
{
    public class Admin : IAdministrator
    {
        private readonly IDataConnection dataContext;

        public Admin(IDataConnection dataContext)
        {
            this.dataContext = dataContext;
        }
        public void ConfigureTariff(TariffType tariff, decimal newPrice)
        {
            using (var db = dataContext.Create())
            {
                var tariffSettings = db.GetTable<TariffSetting>().FirstOrDefault(t => t.TypeValue == tariff.ToString());

                if (tariffSettings == null)
                    throw new Exception($"Тарифная сетка {tariff} не найдена");

                tariffSettings.PricePerHour = newPrice;
                db.Update(tariffSettings);
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

                if (setting == null)
                    throw new Exception($"Тарифная сетка {tariff} не найдена");

                return setting.PricePerHour;
            }
        }
    }
}
