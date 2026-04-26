using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.Library.Database;
using GameClub.Library.Repositories;
using GameClub.Library.RepositoryInterfaces;
using LinqToDB.Data;

namespace GameClub.Library.UnitOfWork
{
    public class UnitOfWorkLinq2db : IUnitOfWork
    {
        private readonly DataConnection connection;
        private bool disposed;
        private bool hasActiveTransaction;

        public ISeatRepository Seats { get; }
        public ISessionRepository Sessions { get; }
        public ITariffSettingRepository Tariffs { get; }
        public IUserRepository Users { get; }

        public UnitOfWorkLinq2db(IDataConnection dataConnection)
        {
            connection = dataConnection.Create();

            Seats = new SeatRepository(connection);
            Sessions = new SessionRepository(connection);
            Tariffs = new TariffSettingRepository(connection);
            Users = new UserRepository(connection);
        }

        public void BeginTransaction()
        {
            if (!hasActiveTransaction)
            {
                connection.BeginTransaction();
                hasActiveTransaction = true;
            }
        }

        public void Commit()
        {
            if (hasActiveTransaction)
            {
                connection.CommitTransaction();
                hasActiveTransaction = false;
            }
        }

        public void RollBack()
        {
            if (hasActiveTransaction)
            {
                connection.RollbackTransaction();
                hasActiveTransaction = false;
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                connection?.Dispose();
                disposed = true;
            }
        }
    }
}
