using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Entity
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string CountryName { get; set; }

        public List<City> Cities { get; set; }      //Navigational Property



        public Country() { }
        public Country(string countryName)
        {
            CountryName = countryName;
        }


    }
}
