using GameClub.Library.Database;

namespace GameClub.Library.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDataConnection _dataConnection;

        public UnitOfWorkFactory(IDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWorkLinq2db(_dataConnection);
        }
    }
}