using _08_People.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.ViewModels
{
    public class CitiesViewModel
    {
        public string CityName { get; set; }

        public List<City> Cities { get; set; }
        public CitiesViewModel() { }
    }
}
