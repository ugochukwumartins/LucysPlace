using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lucysPlace.Models
{
    public class RegistrationPage
    {
        [Required]
        [MinLength(5, ErrorMessage = "Must be at minimum of 5 letters")]
        [MaxLength(100, ErrorMessage = "Must be at maximum of 100 letters")]
        [Display(Name = "Username")]
        public String Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Emal")]
        public String Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(100,ErrorMessage ="Must be at minimum of 5 letters")]
        [MinLength(5, ErrorMessage = "Must be at minimum of 5 letters")]
        [MaxLength(100, ErrorMessage = "Must be at maximum of 100 letters")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        [Display(Name = "ConfirmPassword ")]
        public String ConfirmPassword { get; set; }
    }
}
