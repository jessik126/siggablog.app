using SQLite;

namespace SiggaBlog.Domain.Interface
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
