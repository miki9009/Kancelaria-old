using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models.Cases
{
    public class CaseRemark
    {
        [Display(Name = "Data rozprawy")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string CaseDate { get; set; }

        [Display(Name = "Numer sali")]
        public string CourtRoomNum { get; set; }

        [Display(Name = "UWAGI")]
        public string Remarks { get; set; }
    }
}
