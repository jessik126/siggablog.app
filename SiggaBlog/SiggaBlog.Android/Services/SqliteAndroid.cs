using SiggaBlog.Domain.Interface;
using SiggaBlog.Droid.Services;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteAndroid))]
namespace SiggaBlog.Droid.Services
{
    public class SqliteAndroid : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SiggaDataBase.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);

            return new SQLiteConnection(path);
        }
    }
}