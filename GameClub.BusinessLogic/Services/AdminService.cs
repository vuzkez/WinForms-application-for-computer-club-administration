using GameClub.Domain.Enums;
using GameClub.BusinessLogic.ServiceInterfaces;
using GameClub.DataAccess.UnitOfWork;
using GameClub.Domain.Entities;

namespace GameClub.BusinessLogic.Services
{
    /// <summary>
    /// Реализация административных операций: тарифы, операторы, выручка
    /// </summary>
    public class AdminService : IAdministrator
    {
        private readonly IUnitOfWorkFactory uowFactory;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="uowFactory">Фабрика единиц работы</param>
        public AdminService(IUnitOfWorkFactory uowFactory)
        {
            this.uowFactory = uowFactory;
        }

        /// <summary>
        /// Изменить цену указанного тарифа
        /// </summary>
        public async Task ConfigureTariffAsync(TariffType tariff, decimal newPrice)
        {
            using (var uow = uowFactory.Create())
            {
                await uow.Tariffs.UpdatePriceAsync(tariff, newPrice);
            }
        }

        /// <summary>
        /// Получить общую выручку за заданный период
        /// </summary>
        public async Task<decimal> GetRevenueAsync(DateTime from, DateTime to)
        {
            using (var uow = uowFactory.Create())
            {
                return await uow.Sessions.GetTotalRevenueAsync(from, to);
            }
        }

        /// <summary>
        /// Получить текущую цену тарифа по его типу
        /// </summary>
        public async Task<decimal> GetTariffPriceAsync(TariffType tariff)
        {
            using (var uow = uowFactory.Create())
            {
                return await uow.Tariffs.GetPriceAsync(tariff);
            }
        }

        /// <summary>
        /// Получить список всех операторов
        /// </summary>
        public async Task<List<User>> GetAllOperatorsAsync()
        {
            using (var uow = uowFactory.Create())
            {
                var allUsers = await uow.Users.GetAllAsync();
                return allUsers.Where(u => u.UserRole == UserRole.Operator).ToList();
            }
        }

        /// <summary>
        /// Удалить оператора по идентификатору
        /// </summary>
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

        /// <summary>
        /// Обновить данные существующего оператора
        /// </summary>
        public async Task UpdateOperatorAsync(User user)
        {
            using (var uow = uowFactory.Create())
            {
                await uow.Users.UpdateAsync(user);
            }
        }

        /// <summary>
        /// Добавить нового оператора
        /// </summary>
        public async Task AddOperatorAsync(string login, string password, string fullName)
        {
            using (var uow = uowFactory.Create())
            {
                if (await uow.Users.IsLoginExistsAsync(login))
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