using SiggaBlog.Domain.Entity;
using SiggaBlog.Domain.Interface;
using SQLite;
using Xamarin.Forms;

namespace SiggaBlog.Data
{
    public class SiggaDatabase
    {
        public SQLiteConnection SQLiteConnection { get; private set; }

        public SiggaDatabase()
        {
            SQLiteConnection = DependencyService.Get<ISqlite>().GetConnection();
            CreateAllTables();
        }

        private void CreateAllTables()
        {
            SQLiteConnection.CreateTable<AlbumEntity>();
            SQLiteConnection.CreateTable<CommentEntity>();
            SQLiteConnection.CreateTable<PostEntity>();
        }
    }
}
