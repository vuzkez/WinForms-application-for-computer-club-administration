using LinqToDB.Data;

namespace AdminPanelLibrary.Database
{
    public interface IDataConnection
    {
        DataConnection Create();
    }
}
