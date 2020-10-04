using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Country> Countries { get; }

        IRepository<City> Cities { get; }
        
        void Save();
    }
}
