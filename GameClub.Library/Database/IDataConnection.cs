using LinqToDB.Data;

namespace GameClub.Library.Database
{
    public interface IDataConnection
    {
        DataConnection Create();
    }
}
