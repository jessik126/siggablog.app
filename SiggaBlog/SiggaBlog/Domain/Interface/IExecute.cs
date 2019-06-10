using SiggaBlog.Domain.Entity;
using System;
using System.Collections.Generic;

namespace SiggaBlog.Domain.Interface
{
    public interface IExecute<T> where T : BaseEntity
    {
        void Insert(T obj);

        IEnumerable<T> Get();

        T GetOne(Func<T, bool> predicate);

        IEnumerable<T> Get(Func<T, bool> predicate);
    }
}
