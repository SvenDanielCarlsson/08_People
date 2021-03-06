using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Entity
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public string CityName { get; set; }




        //  Navigational properties
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public List<Person> People { get; set; }

        
        public City()
        {
            this.People = new List<Person>();
        }
        public City(string cityName)
        {
            CityName = cityName;
        }


    }
}
