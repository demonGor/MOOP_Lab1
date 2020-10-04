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
            var context = new MapXmlDataContext("map.xml");
            var unitOfWork = new XmlUnitOfWork(context);
            var countryService = new CountryService(unitOfWork);
            var cityService = new CityService(unitOfWork);

            try
            {
                cityService.AddCity(new City
                {
                    Id = 5,
                    Name = "Харків",
                    Count = 78000,
                    IsCapital = false,
                    CountryId = 1
                });

                countryService.AddCountry(new Country
                {
                    Id = 3,
                    Name = "Франція"
                });

                cityService.AddCity(new City
                {
                    Id = 6,
                    Name = "Париж",
                    Count = 86000,
                    IsCapital = true,
                    CountryId = 3,
                });

                cityService.AddCity(new City
                {
                    Id = 7,
                    Name = "Ренн",
                    Count = 67000,
                    IsCapital = false,
                    CountryId = 3,
                });

                cityService.UpdateCity(new City
                {
                    Id = 7,
                    Name = "Ренн",
                    Count = 60000,
                    IsCapital = false,
                    CountryId = 3,
                });

                countryService.UpdateCountry(new Country
                {
                    Id = 3,
                    Name = "France"
                });

                countryService.AddCountry(new Country
                {
                    Id = 4,
                    Name = "Англія"
                });

                cityService.AddCity(new City
                {
                    Id = 8,
                    Name = "Лондон",
                    Count = 689000,
                    IsCapital = true,
                    CountryId = 4
                });

                cityService.DeleteCityById(8);
                countryService.DeleteCountryById(4);
                
                var countries = countryService.GetAllCountries();
                var unicCountry = countryService.GetCountryById(2);
                var citiesInBel = cityService.GetAllCitiesInCountry(2);
                var unicCity = cityService.GetCityById(4);

                //return to start 

                countryService.DeleteCountryById(3);
                cityService.DeleteCityById(5);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
