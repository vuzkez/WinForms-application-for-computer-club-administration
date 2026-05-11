using GameClub.Domain.Entities;

namespace GameClub.DataAccess.RepositoryInterfaces
{
    /// <summary>
    /// Репозиторий для работы с пользователями
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Получить пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь или null</returns>
        Task<User?> GetByIdAsync(int id);

        /// <summary>
        /// Найти пользователя по логину и паролю
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Пользователь или null</returns>
        Task<User?> GetByLoginAsync(string login, string password);

        /// <summary>
        /// Проверить, занят ли логин
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>true, если логин уже существует</returns>
        Task<bool> IsLoginExistsAsync(string login);
    }
}