namespace GameClub.DataAccess.UnitOfWork
{
    /// <summary>
    /// Фабрика единиц работы
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Создать новую единицу работы
        /// </summary>
        /// <returns>Объект IUnitOfWork</returns>
        IUnitOfWork Create();
    }
}