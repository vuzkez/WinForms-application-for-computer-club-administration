using GameClub.Library.Entities;
using GameClub.Library.Enums;

namespace GameClub.Library.Interfaces
{
    public interface IAdministrator
    {
        Task<decimal> GetRevenueAsync(DateTime from, DateTime to);
        Task ConfigureTariffAsync(TariffType tariff, decimal newPrice);
        Task<decimal> GetTariffPriceAsync(TariffType tariff);
        Task<List<User>> GetAllOperatorsAsync();
        Task DeleteOperatorAsync(int userId);
        Task AddOperatorAsync(string login,string password,string fullName);
        Task UpdateOperatorAsync(User user);
    }
}
