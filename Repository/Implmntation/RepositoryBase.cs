using Domain.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implmntation
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataBaseContext _dataBase;

        public RepositoryBase(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void Add(T entity)
        {
            _dataBase.Set<T>().Add(entity);
        }

        public void AddRange(IQueryable<T> entities)
        {
            _dataBase.Set<T>().AddRange(entities);
        }

        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dataBase.Set<T>().Where(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dataBase.Set<T>();
        }

        public T GetById(int id)
        {
            return _dataBase.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _dataBase.Set<T>().Remove(entity);
        }

        public void RemoveRange(IQueryable<T> entities)
        {
            _dataBase.Set<T>().RemoveRange(entities);
        }
    }
}