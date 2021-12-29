using _08_People.Models.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Entity
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        
        [Required]
        [Phone] //Works?
        public int PhoneNumber { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string InCity { get; set; }
    }
}
