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

        //[Required]
        //[StringLength(50, MinimumLength = 2)]
        //public string InCity { get; set; }    // This will be replaced

        //public Country Country { get; set; }  //Is this neccessary?

        [ForeignKey("City")]
        public int CityId { get; set; }         // Just in case
        public City City { get; set; }          // By this
    }
}
