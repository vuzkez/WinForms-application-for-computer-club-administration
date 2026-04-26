using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary.RepositoryInterfaces
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
