using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CountryService : ICountryService
    {
        private IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void AddCountry(Country country)
        {
            _unitOfWork.Countries.Create(country);
            _unitOfWork.Save();
        }

        public void DeleteCountryById(int id)
        {
            _unitOfWork.Countries.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _unitOfWork.Countries.GetAll();
        }

        public Country GetCountryById(int id)
        {
            return _unitOfWork.Countries.Get(id);
        }

        public void UpdateCountry(Country country)
        {
           _unitOfWork.Countries.Update(country);
           _unitOfWork.Save();
        }
    }
}
