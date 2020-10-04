using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public class XmlUnitOfWork : IUnitOfWork
    {
        private MapXmlDataContext _dataContext;

        private IRepository<Country> _countriesRepository;

        private IRepository<City> _citiesRepository;

        public IRepository<Country> Countries => _countriesRepository ?? (_countriesRepository = new CountriesRepository(_dataContext));

        public IRepository<City> Cities => _citiesRepository ?? (_citiesRepository = new CitiesRepository(_dataContext));

        public XmlUnitOfWork(MapXmlDataContext context)
        {
            _dataContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
