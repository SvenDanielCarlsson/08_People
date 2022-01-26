using _08_People.Models.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Entity
{
    public class Person
    {
        [Key]   // [Key] is the primary index, while [Index] defines the secondary index
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }


        //public Country Country { get; set; }  //Is this neccessary?


        //  Navigational Properties
        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
