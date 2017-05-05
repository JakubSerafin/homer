using homer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homer.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T: IIdentyfiable
    {
        public GenericRepository()
        {

        }

        public GenericRepository(IEnumerable<T> initCollection)
        {
            _collection.InsertRange(0,initCollection);
        }

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
            var index = _collection.FindIndex(_ => _.Id == entity.Id);
            if(index>=0)
            {
                _collection.RemoveAt(index);
                _collection.Add(entity);
            }
            else
            {
                Insert(entity);
            }
        }
    }
}
