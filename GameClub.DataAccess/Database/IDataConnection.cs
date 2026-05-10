using LinqToDB.Data;

namespace GameClub.DataAccess.Database
{
    public interface IDataConnection
    {
        DataConnection Create();
    }
}

