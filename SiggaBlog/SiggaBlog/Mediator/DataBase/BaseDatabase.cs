using SiggaBlog.Domain.Entity;
using SiggaBlog.Domain.Interface;
using SiggaBlog.Domain.Interface.Repository;
using System;
using System.Collections.Generic;

namespace SiggaBlog.Mediator.DataBase
{
    public class BaseDatabase<T> : IExecute<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;

        public BaseDatabase(IBaseRepository<T> repository)
        {
            _repository = repository;

        }


        public IEnumerable<T> Get()
        {
            return _repository.GetMany();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _repository.GetMany(predicate);
        }

        public T GetOne(Func<T, bool> predicate)
        {
            return _repository.GetOne(predicate);
        }

        public void Insert(T obj)
        {
            _repository.Insert(obj);
        }

        public void DeleteAll()
        {
            _repository.DeleteAll();
        }
    }
}
