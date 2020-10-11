using DAL.Entities;
using DAL.EntitiesConfigurations;
using DAL.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContext
{
    public class EFMapDataContext : DbContext
    {
        private const string ConnectionString = "Server=DESKTOP-ANB6B7T\\SQLEXPRESS; Database=MOOP;Trusted_Connection=True;";

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public EFMapDataContext() { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly("DAL")).UseLazyLoadingProxies();
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfigurations());
            modelBuilder.SeedData();

        }
    }
}
