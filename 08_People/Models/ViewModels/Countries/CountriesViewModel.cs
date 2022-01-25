using _08_People.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.ViewModels
{
    public class CountriesViewModel
    {
        public string CountryName { get; set; }

        public List<Country> Countries { get; set; }
        public List<City> Cities { get; set; }
        public CountriesViewModel() { }
    }
}
