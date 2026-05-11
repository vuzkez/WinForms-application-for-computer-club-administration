using GameClub.Domain.Entities;

namespace GameClub.BusinessLogic.ServiceInterfaces
{
    /// <summary>
    /// Сервис аутентификации пользователей
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// Проверить учётные данные и вернуть пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Пользователь или null, если учётные данные неверны</returns>
        Task<User?> LoginAsync(string login, string password);
    }
}