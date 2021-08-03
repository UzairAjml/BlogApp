using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{

    // Attributes of a User



    public class Users
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Name must be in correct format.")]
        [Display(Name = "Username")]
        public string RegisterUsername { get; set; }

        [Required(ErrorMessage = "Email must be in correct format.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string RegisterEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string RegisterPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("RegisterPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }

    }
}
