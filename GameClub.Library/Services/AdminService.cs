using GameClub.Library.Enums;
using GameClub.Library.ServiceInterfaces;
using GameClub.Library.UnitOfWork;

namespace GameClub.Library.Entities
{
    public class AdminService : IAdministrator
    {
        private readonly IUnitOfWorkFactory uowFactory;

        public AdminService(IUnitOfWorkFactory uowFactory)
        {
            this.uowFactory = uowFactory;
        }

        public async Task ConfigureTariffAsync(TariffType tariff, decimal newPrice)
        {
            using (var uow = uowFactory.Create())
            {
                await uow.Tariffs.UpdatePriceAsync(tariff, newPrice);
            }
        }

        public async Task<decimal> GetRevenueAsync(DateTime from, DateTime to)
        {
            using (var uow = uowFactory.Create())
            {
                return await uow.Sessions.GetTotalRevenueAsync(from, to);
            }
        }

        public async Task<decimal> GetTariffPriceAsync(TariffType tariff)
        {
            using (var uow = uowFactory.Create())
            {
                return await uow.Tariffs.GetPriceAsync(tariff);
            }
        }

        public async Task<List<User>> GetAllOperatorsAsync()
        {
            using (var uow = uowFactory.Create())
            {
                var allUsers = await uow.Users.GetAllAsync();
                return allUsers.Where(u => u.UserRole == UserRole.Operator).ToList();
            }
        }

        public async Task DeleteOperatorAsync(int userId)
        {
            using (var uow = uowFactory.Create())
            {
                var user = await uow.Users.GetByIdAsync(userId);
                if (user == null)
                    throw new Exception("Оператор не найден");

                if (user.UserRole != UserRole.Operator)
                    throw new Exception("Нельзя удалить админа!");

                await uow.Users.DeleteAsync(userId);
            }
        }
        public async Task UpdateOperatorAsync(User user)
        {
            using (var uow = uowFactory.Create())
            {
                await uow.Users.UpdateAsync(user);
            }
        }
        public async Task AddOperatorAsync(string login, string password, string fullName)
        {
            using (var uow = uowFactory.Create())
            {
                var existing = await uow.Users.IsLoginExistsAsync(login);

                if (existing == true)
                    throw new Exception($"Логин '{login}' уже занят!");

                var newOper = new User 
                { 
                    FullName = fullName,
                    UserRole = UserRole.Operator,
                    Login = login,
                    Password = password
                };

                await uow.Users.AddAsync(newOper);
            }
        }
    }
}