using AdminPanelLibrary.Enums;
using AdminPanelLibrary.Interfaces;
using AdminPanelLibrary.RepositoryInterfaces;

namespace AdminPanelLibrary.Entities
{
    public class AdminService : IAdministrator
    {
        private readonly ITariffSettingRepository _tariffRepo;
        private readonly ISessionRepository _sessionRepo;

        public AdminService(ITariffSettingRepository tariffRepo, ISessionRepository sessionRepo)
        {
            _tariffRepo = tariffRepo;
            _sessionRepo = sessionRepo;
        }

        public void ConfigureTariff(TariffType tariff, decimal newPrice)
        {
            _tariffRepo.UpdatePrice(tariff, newPrice);
        }

        public decimal GetRevenue(DateTime from, DateTime to)
        {
            return _sessionRepo.GetTotalRevenue(from, to);
        }

        public decimal GetTariffPrice(TariffType tariff)
        {
            return _tariffRepo.GetPrice(tariff);
        }
    }
}