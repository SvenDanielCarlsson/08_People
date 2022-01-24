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
        
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        
        public Country Country { get; set; }        //Navigational property bind

        public List<Person> People { get; set; }    //Navigational property
        
        public City() { }


    }
}
