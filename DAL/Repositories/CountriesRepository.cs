using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class CountriesRepository : IRepository<Country>
    {
        private MapXmlDataContext _context;
        public CountriesRepository(MapXmlDataContext mapXmlDataContext)
        {
            _context = mapXmlDataContext ?? throw new ArgumentNullException(nameof(mapXmlDataContext));
        }

        public void Create(Country item)
        {
            _context.Countries.Add(item);
        }

        public void Delete(int id)
        {
            var item = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _context.Countries.Remove(item);
                _context.Cities.RemoveAll(c => c.CountryId == item.Id);
            }
        }

        public Country Get(int id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Country> GetAll()
        {
            return _context.Countries;
        }

        public void Update(Country item)
        {
            var old = _context.Countries.FirstOrDefault(c => c.Id == item.Id);
            if (item != null && old != null)
            {
                old.Name = item.Name;
            }
        }
    }
}
