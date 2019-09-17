using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models.AccountViewModels
{
    public class LoginWith2faViewModel
    {
        [Required(ErrorMessageResourceName = "To pole jest wymagane")]
        [StringLength(7, ErrorMessage = "{0} musi mieć przynajmniej {2} znaków długości i maksymalnie {1} znaków.", MinimumLength = 8)]
        [DataType(DataType.Text)]
        [Display(Name = "Kod potwierdzenia")]
        public string TwoFactorCode { get; set; }

        [Display(Name = "Zapamiętaj to urządzenie")]
        public bool RememberMachine { get; set; }

        public bool RememberMe { get; set; }
    }
}
