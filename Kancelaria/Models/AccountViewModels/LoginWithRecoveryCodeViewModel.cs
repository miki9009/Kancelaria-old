using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models.AccountViewModels
{
    public class LoginWithRecoveryCodeViewModel
    {
        [Required(ErrorMessageResourceName = "To pole jest wymagane")]
        [DataType(DataType.Text)]
            [Display(Name = "Kod odzyskiwania")]
            public string RecoveryCode { get; set; }
    }
}
