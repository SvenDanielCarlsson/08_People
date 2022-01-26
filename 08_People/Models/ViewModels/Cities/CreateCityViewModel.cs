using _08_People.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.ViewModels
{
    public class CreateCityViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string CityName { get; set; }

        [Required]
        [DisplayName("Country")]
        public int CountryId { get; set; }
        public List<Country> CountryList { get; set; } 
    }
}
