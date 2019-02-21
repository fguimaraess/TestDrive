using SQLite;

namespace TestDrive.Data
{
    public interface ISqLite
    {
        SQLiteConnection PegarConexao();
    }
}
