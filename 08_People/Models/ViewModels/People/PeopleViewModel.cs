using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using _08_People.Models.Entity;
using _08_People.Models.Repos;

namespace _08_People.Models.ViewModels
{
    public class PeopleViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string InCity { get; set; }

        public Country Country { get; set; }
        public City City { get; set; }


        public List<Person> Persons { get; set; }
        public List<City> CityList { get; set; }    //Reduntant i think
        public PeopleViewModel() {}
        
    }
}
