using AdminPanelLibrary.Entities;
using AdminPanelLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary.RepositoryInterfaces
{
    public interface ITariffSettingRepository : IRepository<TariffSetting>
    {
        Task<decimal> GetPriceAsync(TariffType tariff);
        Task UpdatePriceAsync(TariffType tariff, decimal newPrice);
        Task<TariffSetting?> GetByTypeAsync(TariffType tariff);
    }
}
