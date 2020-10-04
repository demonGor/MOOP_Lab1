using DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace DAL.DataContext
{
    public class MapXmlDataContext
    {
        public List<Country> Countries { get; set; }

        public List<City> Cities { get; set; }

        private XDocument _xmlDocument;

        private string _path;

        public MapXmlDataContext(string filePath)
        {
            _path = filePath;
            LoadFromXmlToContext();
        }

        public void SaveChanges()
        {
            _xmlDocument.Root.Elements("Country").Remove();
            foreach(var country in Countries)
            {
                var countryToAdd = new XElement("Country",
                      new XAttribute("id", country.Id),
                      new XAttribute("name", country.Name));
              
                foreach(var city in country.Cities)
                {
                    countryToAdd.Add(new XElement("City",
                      new XAttribute("id", city.Id),
                      new XAttribute("name", city.Name),
                      new XAttribute("iscap", Convert.ToInt32(city.IsCapital)),
                      new XAttribute("count", city.Count)));
                }
                _xmlDocument.Root.Add(countryToAdd);
            }

            _xmlDocument.Save(_path);
            LoadFromXmlToContext();
        }

        public void LoadFromXmlToContext()
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            var path = new Uri(Directory.GetCurrentDirectory());
            schema.Add("", path + "\\map.xsd");
            XmlReader rd = XmlReader.Create(_path);
            _xmlDocument = XDocument.Load(rd);
            rd.Close();
            _xmlDocument.Validate(schema, ValidationEventHandler);

            Countries = new List<Country>();
            Cities = new List<City>();

            foreach (XElement country in _xmlDocument.Element("Map").Elements("Country"))
            {
                var countryToAdd = new Country()
                {
                    Id = Convert.ToInt32(country.Attribute("id").Value),
                    Name = country.Attribute("name").Value
                };

                foreach(XElement city in country.Elements("City"))
                    {
                    var cityToAdd = new City()
                    {
                        Id = Convert.ToInt32(city.Attribute("id").Value),
                        Name = city.Attribute("name").Value,
                        CountryId = countryToAdd.Id,
                        Country = countryToAdd,
                        IsCapital = Convert.ToBoolean(Convert.ToInt32(city.Attribute("iscap").Value)),
                        Count = Convert.ToInt32(city.Attribute("count").Value)
                    };

                    countryToAdd.Cities.Add(cityToAdd);
                    Cities.Add(cityToAdd);
                    }
                Countries.Add(countryToAdd);
            }
        }
        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error) throw new Exception(e.Message);
            }
        }
    }
}
