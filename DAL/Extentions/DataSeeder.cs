using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Extentions
{
    public static class DataSeeder
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData
                (
                new Country { Id = 1, Name = "Україна"},
                new Country { Id = 2, Name = "Білорусь"},
                new Country { Id = 3, Name = "Франція"}
                );

            modelBuilder.Entity<City>().HasData
                (
                new City { Id = 1, Name = "Київ", IsCapital = true, Count = 3000000, CountryId =1 },
                new City { Id = 2, Name = "Львів", IsCapital = false, Count = 2000000, CountryId = 1 },
                new City { Id = 3, Name = "Харків", IsCapital = false, Count = 2000000, CountryId = 1 }
                );
        }
    }
}
