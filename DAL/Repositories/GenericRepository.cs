using DAL.DataContext;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public GenericRepository(EFMapDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> _dbSet => _dbContext.Set<T>();
        public EFMapDataContext _dbContext { get; }


        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Delete(int Id)
        {
 
            var entity = Get(Id);
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new Exception("Empty entity to modify");

            _dbSet.Update(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
