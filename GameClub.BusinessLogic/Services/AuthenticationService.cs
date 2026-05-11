using GameClub.BusinessLogic.ServiceInterfaces;
using GameClub.DataAccess.UnitOfWork;
using GameClub.Domain.Entities;

namespace GameClub.BusinessLogic.Services
{
    /// <summary>
    /// Реализация сервиса аутентификации пользователей
    /// </summary>
    public class AuthenticationService : IAuthentication
    {
        private readonly IUnitOfWorkFactory uowFactory;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="uowFactory">Фабрика единиц работы</param>
        public AuthenticationService(IUnitOfWorkFactory uowFactory)
        {
            this.uowFactory = uowFactory;
        }

        /// <summary>
        /// Проверить учётные данные и вернуть пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Пользователь или null, если учётные данные неверны</returns>
        public async Task<User?> LoginAsync(string login, string password)
        {
            using (var uow = uowFactory.Create())
            {
                var user = await uow.Users.GetByLoginAsync(login, password);

                if (user != null)
                {
                    return user;
                }
                return null;
            }
        }
    }
}