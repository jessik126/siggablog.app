using SiggaBlog.Domain.Entity;
using System;
using System.Collections.Generic;

namespace SiggaBlog.Domain.Interface.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetMany();

        IEnumerable<T> GetMany(Func<T, bool> predicate);

        T GetOne(Func<T, bool> predicate);

        void Insert(T item);

        void DeleteAll();
    }
}
