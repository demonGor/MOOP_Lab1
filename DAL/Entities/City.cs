using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCapital { get; set; }
        public int Count { get; set; }

        public int CountryId { get; set; }
       
        public Country Country { get; set; }
    }
}
