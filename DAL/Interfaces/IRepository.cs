using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);

        TEntity Get(int id);
        
        IEnumerable<TEntity> GetAll();
      
        void Delete(int id);

        void Update(TEntity item);
    }
}
