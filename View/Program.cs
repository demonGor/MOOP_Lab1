using BLL.Services;
using DAL.DataContext;
using DAL.Entities;
using DAL.Repositories;
using DAL.UnitOfWork;
using System;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new EFMapDataContext();
            var unitOfWork = new EFUnitOfWork(context);
            var countryService = new CountryService(unitOfWork);
            var cityService = new CityService(unitOfWork);

            try
            {

                var countries = countryService.GetAllCountries();
                var unicCountry = countryService.GetCountryById(2);
                var citiesInBel = cityService.GetAllCitiesInCountry(1);
                var unicCity = cityService.GetCityById(4);

                //return to start 

                //countryService.DeleteCountryById(3);
                //cityService.DeleteCityById(5);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            context.Dispose();
            Console.ReadKey();
        }
    }
}
