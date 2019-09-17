using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessageResourceName = "To pole jest wymagane")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
