using LinqToDB.Data;

namespace AdminPanelLibrary.Repositories
{
    public interface IDataConnection
    {
        DataConnection Create();
    }
}
