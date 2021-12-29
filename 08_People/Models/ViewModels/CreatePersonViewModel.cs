﻿using System;
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
        //[Phone] //Works not that well for me
        [DisplayName("Phonenumber")]
        public int PhoneNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("City")]
        public string InCity { get; set; }
    }
}