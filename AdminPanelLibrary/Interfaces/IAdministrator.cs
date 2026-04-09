using AdminPanelLibrary.Enums;

namespace AdminPanelLibrary.Interfaces
{
    public interface IAdministrator
    {
        decimal GetRevenue(DateTime from, DateTime to);
        void ConfigureTariff(TariffType tariff, decimal newPrice);
        decimal GetTariffPrice(TariffType tariff);
    }
}
