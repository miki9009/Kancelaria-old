using Kancelaria.Data;
using Kancelaria.Models.Cases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models
{
    public class Participant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

        public ICollection<Participant> participants { get; set; }

        public int ID { get; set; }
        public int CaseID { get; set; }

        
        [Display(Name = "Typ uczesnika")]
        public string Type { get; set; }

        
        [Display(Name = "Imię", Prompt ="Imię")]
        [RegularExpression(@"^[a-zA-Z-ĄąśŚćĆęĘÓóŹźŻżńŃłŁ\s]{1,40}$",
         ErrorMessage = "Nie poprawny format, element może używać jedynie znaków a-ż A-Ż. max=40 znaków")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko", Prompt = "Nazwisko")]
        [RegularExpression(@"^[a-zA-Z-ĄąśŚćĆęĘÓóŹźŻżńŃłŁ\s]{1,40}$",
         ErrorMessage = "Nie poprawny format, element może używać jedynie znaków a-ż A-Ż. max=40 znaków")]
        public string Surname { get; set; }

        [Display(Name = "Miejscowość", Prompt = "Miejscowość")]
        [RegularExpression(@"^[a-zA-Z-ĄąśŚćĆęĘÓóŹźŻżńŃłŁ\s]{1,40}$",
         ErrorMessage = "Nie poprawny format, element może używać jedynie znaków a-ż A-Ż. max=40 znaków")]
        public string Town { get; set; }

            
        [Display(Name = "Kod pocztowy", Prompt = "00-000")]
        [DataType(DataType.PostalCode)]
        public string PostCode { get; set; }

        [Display(Name = "Ulica", Prompt = "Ulica")]
        public string Street { get; set; }

        [Display(Name = "Nr budynku / mieszkania", Prompt = "0/0")]
        public string BuildingNum { get; set; }


        [Display(Name = "Województwo")]
        public string Voivodship { get; set; }

        [Display(Name = "Powiat", Prompt = "Powiat")]
        [RegularExpression(@"^[a-zA-Z-ĄąśŚćĆęĘÓóŹźŻżńŃłŁ\s]{1,40}$",
         ErrorMessage = "Nie poprawny format, element może używać jedynie znaków a-ż A-Ż. max=40 znaków")]
        public string County { get; set; }

        [Display(Name = "NIP", Prompt = "000-00-00-000")]
        [RegularExpression(@"^[0-9-]*$",
        ErrorMessage = "Niepoprawny format, NIP składa się jedynie z cyfr, np. 0123456789 lub 123-456-78-19")]
        public string NIP { get; set; }

        [Display(Name = "PESEL", Prompt = "00000000000")]
        [RegularExpression(@"^[0-9]*$",
         ErrorMessage = "Niepoprawny format, PESEL składa się jedynie z cyfr")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Numer PESEL musi składać się z 11 cyfr.")]
        public string Pesel { get; set; }

        [Display(Name = "Nr dowodu ", Prompt = "AAA000000")]
        [RegularExpression(@"^[0-9A-Z]*$",
         ErrorMessage = "Niepoprawny format, nr dowodu osobistego składa się z 3 liter i z 6 cyfr np. ABC123456")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Numer dowodu osobistego musi składać się z 9 znakow np. ABC123456.")]
        public string IdentityNum { get; set; }

        [Display(Name = "E-mail", Prompt = "przyklad@email.com")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Niepoprawny format, przyklad@mail.com", 
        ErrorMessageResourceName = "Niepoprawny format, przyklad@mail.com" )]
        public string mail { get; set; }

        
        [Display(Name = "tel. stacjonarny", Prompt = "+00-00-000-00-00")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Nieprawidłowy format")]
        public string phone { get; set; }

        [Display(Name = "tel. komórkowy", Prompt = "+00-000-000-000")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Nieprawidłowy format")]
        public string phoneMobile { get; set; }


    }
}
