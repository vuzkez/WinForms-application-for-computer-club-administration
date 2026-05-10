using GameClub.Domain.Entities;
using GameClub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClub.DataAccess.RepositoryInterfaces
{
    public interface ITariffSettingRepository : IRepository<TariffSetting>
    {
        Task<decimal> GetPriceAsync(TariffType tariff);
        Task UpdatePriceAsync(TariffType tariff, decimal newPrice);
        Task<TariffSetting?> GetByTypeAsync(TariffType tariff);
        Task<int> GetIdByTypeAsync (TariffType tariff);
        Task<TariffSetting> GetByIdAsync(int tariffId);
    }
}

