using LinqToDB.Data;

namespace AdminPanelLibrary
{
    public interface IDataConnection
    {
        DataConnection Create();
    }
}
