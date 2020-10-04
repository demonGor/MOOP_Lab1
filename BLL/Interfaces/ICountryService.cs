using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICountryService
    {
        IEnumerable<Country> GetAllCountries();

        Country GetCountryById(int id);

        void AddCountry(Country country);

        void UpdateCountry(Country country);

        void DeleteCountryById(int id);
    }
}
