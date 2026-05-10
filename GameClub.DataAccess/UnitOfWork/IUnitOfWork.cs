using GameClub.DataAccess.RepositoryInterfaces;

namespace GameClub.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISeatRepository Seats { get; }
        ISessionRepository Sessions { get; }
        ITariffSettingRepository Tariffs { get; }
        IUserRepository Users { get; }

        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
