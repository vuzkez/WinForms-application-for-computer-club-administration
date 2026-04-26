using GameClub.Library.Enums;

namespace GameClub.Library.Interfaces
{
    public interface IAdministrator
    {
        Task<decimal> GetRevenueAsync(DateTime from, DateTime to);
        Task ConfigureTariffAsync(TariffType tariff, decimal newPrice);
        Task<decimal> GetTariffPriceAsync(TariffType tariff);
    }
}
