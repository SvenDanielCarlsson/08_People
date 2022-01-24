using _08_People.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.ViewModels
{
    public class CreateCityViewModel
    {
        public string CityName { get; set; }

        [Required]
        public int CountryId { get; set; }
        public List<Country> CountryList { get; set; } 
    }
}
