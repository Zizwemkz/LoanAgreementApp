using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanAgreementAPI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
       public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
       public string LastName { get; set; }
      
        [Required]
        [Display(Name = "Phone Number")]
       public string phone { get; set; }
    }
}
