namespace AdminPanelLibrary
{
    public interface IAdministrator
    {
        decimal GetRevenue(DateTime from, DateTime to);
        void ConfigureTariff(TariffType tariff, decimal newPrice);
        decimal GetTariffPrice(TariffType tariff);
    }
}
