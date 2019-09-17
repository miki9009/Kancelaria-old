using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models
{
    public class KancelariaUser
    {
        public ICollection<KancelariaUser> kancelariaUsers { get; set; }

        public int ID { get; set; }

        [Display(Name = "Nazwa firmy:")]
        public string CompanyName { get; set; }

        [Display(Name = "Miejscowość:")]
        public string Town { get; set; }

        [Display(Name = "Ulica:")]
        public string Street { get; set; }

        [Display(Name = "Województwo:")]
        public string Voivodship { get; set; }

        [Display(Name = "Powiat:")]
        public string County { get; set; }

        [Display(Name = "NIP:")]
        public string NIP { get; set; }

        [Display(Name = "KRS:")]
        public string KRS { get; set; }

        [Display(Name = "REGON:")]
        public string REGON { get; set; }

        [Display(Name = "Numer budynku:")]
        public string BuildingNum { get; set; }

        [Display(Name = "Kod pocztowy:")]
        public string PostCode { get; set; }

        [Display(Name = "Mail:")]
        public string Mail { get; set; }

        [Display(Name = "Telefon:")]
        public string Phone { get; set; }

        [Display(Name = "Strona internetowa:")]
        public string HomePage { get; set; }

        public string LastLogIn { get; set; }
        public string UserID { get; set; }
    }
}
