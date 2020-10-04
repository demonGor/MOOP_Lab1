using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CityService : ICityService
    {
        private IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void AddCity(City city)
        {
            _unitOfWork.Cities.Create(city);
            _unitOfWork.Save();
        }

        public void DeleteCityById(int id)
        {
            _unitOfWork.Cities.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<City> GetAllCitiesInCountry(int countryId)
        {
            return _unitOfWork.Countries.Get(countryId)?.Cities;
        }

        public City GetCityById(int id)
        {
           return _unitOfWork.Cities.Get(id);
        }

        public void UpdateCity(City city)
        {
            _unitOfWork.Cities.Update(city);
            _unitOfWork.Save();
        }
    }
}
