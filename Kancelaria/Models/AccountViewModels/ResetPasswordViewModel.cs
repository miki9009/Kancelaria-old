using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessageResourceName = "To pole jest wymagane")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "To pole jest wymagane")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Pole hasło i pole potwierdź hasło mają inną wartość")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
