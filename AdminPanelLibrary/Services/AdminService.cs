using AdminPanelLibrary.Enums;
using AdminPanelLibrary.Interfaces;
using AdminPanelLibrary.Database;
using AdminPanelLibrary.UnitOfWork;

namespace AdminPanelLibrary.Entities
{
    public class AdminService : IAdministrator
    {
        private readonly IDataConnection dataConnection;

        public AdminService(IDataConnection dataConnection)
        {
            this.dataConnection = dataConnection;
        }

        public async Task ConfigureTariffAsync(TariffType tariff, decimal newPrice)
        {
            using (var uow = new UnitOfWorkLinq2db(dataConnection))
            {
                await uow.Tariffs.UpdatePriceAsync(tariff, newPrice);
            }
        }

        public async Task<decimal> GetRevenueAsync(DateTime from, DateTime to)
        {
            using (var uow = new UnitOfWorkLinq2db(dataConnection))
            {
                return await uow.Sessions.GetTotalRevenueAsync(from, to);
            }
        }

        public async Task<decimal> GetTariffPriceAsync(TariffType tariff)
        {
            using (var uow = new UnitOfWorkLinq2db(dataConnection))
            {
                return await uow.Tariffs.GetPriceAsync(tariff);
            }
        }
    }
}