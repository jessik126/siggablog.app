using SiggaBlog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiggaBlog.Data.Repository
{
    public class BaseRepository<T> where T : BaseEntity, new()
    {
        private readonly SiggaDatabase siggaDataBase;

        public BaseRepository()
        {
            siggaDataBase = new SiggaDatabase();
        }


        public IEnumerable<T> GetMany()
        {
            return siggaDataBase.SQLiteConnection.Table<T>();
        }

        public IEnumerable<T> GetMany(Func<T, bool> predicate)
        {
            return siggaDataBase.SQLiteConnection.Table<T>().Where(predicate);
        }

        public T GetOne(Func<T, bool> predicate)
        {
            return siggaDataBase.SQLiteConnection.Table<T>().FirstOrDefault(predicate);
        }

        public void Insert(T item)
        {
            siggaDataBase.SQLiteConnection.Insert(item);
        }

        public void DeleteAll()
        {
            siggaDataBase.SQLiteConnection.DeleteAll<T>();
        }


    }
}
