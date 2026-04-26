using AdminPanelLibrary.Enums;

namespace AdminPanelLibrary.Interfaces
{
    public interface IAdministrator
    {
        Task<decimal> GetRevenueAsync(DateTime from, DateTime to);
        Task ConfigureTariffAsync(TariffType tariff, decimal newPrice);
        Task<decimal> GetTariffPriceAsync(TariffType tariff);
    }
}
