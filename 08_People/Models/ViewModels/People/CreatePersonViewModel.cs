using _08_People.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phonenumber")]
        public int PhoneNumber { get; set; }



        //[Required]
        //[DisplayName("Country")]
        //public Country Country { get; set; }        // Redundant??



        [Required]
        [DisplayName("City")]
        public int CityId { get; set; }
        public List<City> CityList { get; set; }



        public CreatePersonViewModel()
        {
            this.CityList = new List<City>();
        }
        public CreatePersonViewModel(string firstName, string lastName, int phoneNumber, int cityId) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            CityId = cityId;
        }

    }
}
