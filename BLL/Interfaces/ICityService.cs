using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
   public interface ICityService
    {
        IEnumerable<City> GetAllCitiesInCountry(int countryId);

        City GetCityById(int id);

        void AddCity(City city);

        void UpdateCity(City city);

        void DeleteCityById(int id);
    }
}
