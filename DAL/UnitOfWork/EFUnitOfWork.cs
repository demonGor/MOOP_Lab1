using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
   public class EFUnitOfWork : IUnitOfWork
    {
        private EFMapDataContext _dataContext;

        private IRepository<Country> _countriesRepository;

        private IRepository<City> _citiesRepository;

        public IRepository<Country> Countries => _countriesRepository ?? (_countriesRepository = new GenericRepository<Country>(_dataContext));

        public IRepository<City> Cities => _citiesRepository ?? (_citiesRepository = new GenericRepository<City>(_dataContext));

        public EFUnitOfWork(EFMapDataContext context)
        {
            _dataContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
