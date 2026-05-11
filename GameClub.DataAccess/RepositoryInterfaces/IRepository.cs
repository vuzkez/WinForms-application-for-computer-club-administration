namespace GameClub.DataAccess.RepositoryInterfaces
{
    /// <summary>
    /// Обобщённый интерфейс репозитория для работы с сущностями
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity">Сущность с обновлёнными данными</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Добавить новую сущность
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Удалить сущность по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Получить все сущности данного типа
        /// </summary>
        /// <returns>Список всех сущностей</returns>
        Task<List<T>> GetAllAsync();
    }
}