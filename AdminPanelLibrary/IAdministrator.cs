using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public interface IAdministrator
    {
        decimal GetRevenue(DateTime from, DateTime to);
        void ConfigureTariff(TariffType tariff, decimal newPrice);
        decimal GetTariffPrice(TariffType tariff);
    }
}
