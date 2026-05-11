using GameClub.DataAccess.RepositoryInterfaces;
using GameClub.Domain.Entities;
using LinqToDB;
using LinqToDB.Async;
using LinqToDB.Data;

namespace GameClub.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для работы с пользователями (Users)
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly DataConnection db;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connection">Подключение к базе данных</param>
        public UserRepository(DataConnection connection)
        {
            db = connection;
        }

        /// <summary>
        /// Добавить нового пользователя
        /// </summary>
        public async Task AddAsync(User entity)
        {
            await db.InsertAsync(entity);
        }

        /// <summary>
        /// Обновить данные пользователя
        /// </summary>
        public async Task UpdateAsync(User entity)
        {
            await db.UpdateAsync(entity);
        }

        /// <summary>
        /// Удалить пользователя по идентификатору
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var user = await db.GetTable<User>().FirstOrDefaultAsync(u => u.UserId == id);
            if (user != null)
                await db.DeleteAsync(user);
        }

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns>Список всех пользователей</returns>
        public async Task<List<User>> GetAllAsync()
        {
            return await db.GetTable<User>().ToListAsync();
        }

        /// <summary>
        /// Получить пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь или null</returns>
        public async Task<User?> GetByIdAsync(int id)
        {
            return await db.GetTable<User>().FirstOrDefaultAsync(u => u.UserId == id);
        }

        /// <summary>
        /// Найти пользователя по логину и паролю
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Пользователь или null</returns>
        public async Task<User?> GetByLoginAsync(string login, string password)
        {
            return await db.GetTable<User>()
                .FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        }

        /// <summary>
        /// Проверить, занят ли логин
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>true, если логин уже существует</returns>
        public async Task<bool> IsLoginExistsAsync(string login)
        {
            return await db.GetTable<User>().AnyAsync(u => u.Login == login);
        }
    }
}