using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Podano nieprawidłowy email")]
        [EmailAddress (ErrorMessage = "Podano nieprawidłowy email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Podano nieprawidłowe hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj?")]
        public bool RememberMe { get; set; }
    }
}
