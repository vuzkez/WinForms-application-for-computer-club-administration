using AdminPanelLibrary.Entities;
using AdminPanelLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary.Repositories
{
    public interface ITariffSettingRepository : IRepository<TariffSetting>
    {
        decimal GetPrice(TariffType tariff);
        void UpdatePrice(TariffType tariff, decimal newPrice);
        TariffSetting? GetByType(TariffType tariff);
    }
}
