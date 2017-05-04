using homer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homer.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T: IIdentyfiable
    {
        List<T> _collection = new List<T>();
        public void Delete(T entity)
        {
            _collection.Remove(entity);
        }

        public IQueryable<T> Get()
        {
            return _collection.AsQueryable();
        }

        public T GetByID(int id)
        {
            return _collection.FirstOrDefault(_ => _.Id == id);
        }

        public void Insert(T entity)
        {
            _collection.Add(entity);
        }

        public void Save()
        {
            
        }

        public void Update(T entity)
        {
            
        }
    }
}
