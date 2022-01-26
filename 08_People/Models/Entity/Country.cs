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


        //  Navigational Property
        public List<City> Cities { get; set; }


        public Country()
        {
            this.Cities = new List<City>();
        }
        public Country(string countryName) : this()
        {
            CountryName = countryName;
        }


    }
}
