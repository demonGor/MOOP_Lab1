using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class CitiesRepository : IRepository<City>
    {
        private MapXmlDataContext _context;
        public CitiesRepository(MapXmlDataContext mapXmlDataContext)
        {
            _context = mapXmlDataContext ?? throw new ArgumentNullException(nameof(mapXmlDataContext));
        }

        public void Create(City item)
        {
            _context.Cities.Add(item);
            _context.Countries.FirstOrDefault(c => c.Id == item.CountryId)?.Cities.Add(item);
        }

        public void Delete(int id)
        {
            var item = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _context.Cities.Remove(item);
                _context.Countries.FirstOrDefault(c => c.Id == item.CountryId)?.Cities.Remove(item);
            }
        }

        public City Get(int id)
        {
            return _context.Cities.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<City> GetAll()
        {
            return _context.Cities.ToList();
        }

        public void Update(City item)
        {
            var old = _context.Cities.FirstOrDefault(c => c.Id == item.Id);
            if (item != null && old != null)
            {
                old.Count = item.Count;
                old.IsCapital = item.IsCapital;
                old.Name = item.Name;

                _context.Countries.FirstOrDefault(c => c.Id == old.CountryId)?.Cities.Remove(old);
                old.CountryId = item.CountryId;
                _context.Countries.FirstOrDefault(c => c.Id == item.CountryId)?.Cities.Add(old);

            }
        }
    }
}
