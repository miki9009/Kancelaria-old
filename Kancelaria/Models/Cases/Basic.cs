using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models.Cases
{
    public class Basic
    {
        public static List<string> voivodshipList = new List<string>() {"", "dolnośląskie", "kujawsko-pomorskie", "lubelskie",
            "lubuskie","łódzkie","małopolskie","mazowieckie","opolskie","podkarpackie","podlaskie","pomorskie","śląskie", "świętokrzyskie",
            "warmińsko-mazurskie","wielkopolskie","zachodniopomorskie" };

        public static List<string> categoriesList = new List<string>() {"", "administracyjna", "cywilna", "egzekucyjna",
            "egzekucyjna-wyjawnienia majątku","klauzulowa","karna","procesowa","o zapłatę","o odszkodowanie","opinia","podatkowa","prawo pracy", "renta",
            "ubezpieczenie społeczne","wyjawienie majątku","wypadkowa","zadośćuczyenienie","inna" };

        public static List<string> subjectList = new List<string>() {"", "cywilna", "o zapłatę", "odszkodowanie", "renta", "wypadkowa", "zadośćuczynienie", "inna" };

        public static string[] casePositionList = {" ", "oskarżyciel", "obwiniony/oskarżony", "powód", "pozwany" };

        public ICollection<Basic> basics { get; set; }
        public int ID { get; set; }
        public int CaseID { get; set; }

        [Display(Name = "Przedmiot sprawy")]
        public int CaseSubject { get; set; }

        [Display(Name = "Pozycja w sprawie")]
        public int CasePosition { get; set; }

        [Display(Name = "Kategoria sprawy")]
        public int CaseCategory { get; set; }


        //POWÓD
        [Display(Name = "Imię", Prompt = "Imię")]
        [RegularExpression(@"^[a-zA-Z-ĄąśŚćĆęĘÓóŹźŻżńŃłŁ\s]{1,40}$",
        ErrorMessage = "Nie poprawny format, element może używać jedynie znaków a-ż A-Ż. max=40 znaków")]
        public string S1Name { get; set; }

        [Display(Name = "Nazwisko",Prompt = "Nazwisko")]
        [RegularExpression(@"^[a-zA-Z-ĄąśŚćĆęĘÓóŹźŻżńŃłŁ\s]{1,40}$",
        ErrorMessage = "Nie poprawny format, element może używać jedynie znaków a-ż A-Ż. max=40 znaków")]
        public string S1Surname { get; set; }

        [Display(Name = "Nazwa Firmy", Prompt = "Nazwa Firmy")]
        [MaxLength(75, ErrorMessage = "Nie poprawny format, max=75 znaków")]
        public string S1Company { get; set; }

        [Display(Name = "Miejscowość", Prompt = "Miejscowość")]
        [RegularExpression(@"^[a-zA-Z-ĄąśŚćĆęĘÓóŹźŻżńŃłŁ\s]{1,40}$",
        ErrorMessage = "Nie poprawny format, element może używać jedynie znaków a-ż A-Ż. max=40 znaków")]
        public string S1Town { get; set; }

        [Display(Name = "Kod pocztowy", Prompt = "00-000")]
        [DataType(DataType.PostalCode)]
        public string S1PostCode { get; set; }

        [Display(Name = "Ulica", Prompt = "Ulica")]
        public string S1Street { get; set; }

        [Display(Name = "Nr budynku / mieszkania", Prompt = "0/0")]
        public string S1BuildingNum { get; set; }

        [Display(Name = "Województwo", Prompt = "Województwo")]
        public string S1Voivodship { get; set; }

        [Display(Name = "Powiat", Prompt = "Powiat")]
        [RegularExpression(@"^[a-zA-Z-ĄąśŚćĆęĘÓóŹźŻżńŃłŁ\s]{1,40}$",
         ErrorMessage = "Nie poprawny format, element może używać jedynie znaków a-ż A-Ż. max=40 znaków")]
        public string S1County { get; set; }

        [Display(Name = "Obywatelstwo", Prompt = "Obywatelstwo")]
        public string S1Country { get; set; }

        [Display(Name = "NIP", Prompt = "000-00-00-000")]
        [RegularExpression(@"^[0-9-]*$",
        ErrorMessage = "Niepoprawny format, NIP składa się jedynie z cyfr, np. 0123456789 lub 123-456-78-19")]
        public string S1NIP { get; set; }

        [Display(Name = "PESEL", Prompt = "00000000000")]
        [RegularExpression(@"^[0-9]*$",
        ErrorMessage = "Niepoprawny format, PESEL składa się jedynie z cyfr")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Numer PESEL musi składać się z 11 cyfr.")]
        public string S1PESEL { get; set; }

        [Display(Name = "Nr dowodu ", Prompt = "AAA000000")]
        [RegularExpression(@"^[0-9A-Z]*$",
        ErrorMessage = "Niepoprawny format, nr dowodu osobistego składa się z 3 liter i z 6 cyfr np. ABC123456")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Numer dowodu osobistego musi składać się z 9 znakow np. ABC123456.")]
        public string S1IdentityNum { get; set; }

        [Display(Name = "E-mail", Prompt = "przyklad@mail.com")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Niepoprawny format, przyklad@mail.com",
        ErrorMessageResourceName = "Niepoprawny format, przyklad@mail.com")]
        public string S1Mail { get; set; }

        [Display(Name = "tel. stacjonarny", Prompt = "+00 00 000 00 00")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Nieprawidłowy format")]
        public string S1TelHomeNum { get; set; }

        [Display(Name = "tel. komórkowy", Prompt = "+00 000 000 000")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Nieprawidłowy format")]
        public string S1TelCell { get; set; }

        [Display(Name = "KRS", Prompt = "0000000000")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Numer KRS musi składać się z 10 cyfr.")]
        [RegularExpression(@"^[0-9]*$",
        ErrorMessage = "Niepoprawny format, KRS składa się jedynie z cyfr")]
        public string S1KRS { get; set; }

        [Display(Name = "REGON", Prompt = "0000000000")]
        public string S1REGON { get; set; }

        //POZWANY
        [Display(Name = "Imię", Prompt = "Imię")]
        [RegularExpression(@"^[a-zA-Z-ĄąśŚćĆęĘÓóŹźŻżńŃłŁ\s]{1,40}$",
        ErrorMessage = "Nie poprawny format, element może używać jedynie znaków a-ż A-Ż. max=40 znaków")]
        public string S2Name { get; set; }

        [Display(Name = "Nazwisko", Prompt = "Nazwisko")]
        [RegularExpression(@"^[a-zA-Z-ĄąśŚćĆęĘÓóŹźŻżńŃłŁ\s]{1,40}$",
        ErrorMessage = "Nie poprawny format, element może używać jedynie znaków a-ż A-Ż. max=40 znaków")]
        public string S2Surname { get; set; }

        [Display(Name = "Nazwa Firmy", Prompt = "Nazwa Firmy")]
        [MaxLength(75, ErrorMessage = "Nie poprawny format, max=75 znaków")]
        public string S2Company { get; set; }

        [Display(Name = "Miejscowość", Prompt = "Miejscowość")]
        [RegularExpression(@"^[a-zA-Z-ĄąśŚćĆęĘÓóŹźŻżńŃłŁ\s]{1,40}$",
        ErrorMessage = "Nie poprawny format, element może używać jedynie znaków a-ż A-Ż. max=40 znaków")]
        public string S2Town { get; set; }

        [Display(Name = "Kod pocztowy", Prompt = "00-000")]
        [DataType(DataType.PostalCode)]
        public string S2PostCode { get; set; }

        [Display(Name = "Ulica", Prompt = "Ulica")]
        public string S2Street { get; set; }

        [Display(Name = "Nr budynku / mieszkania", Prompt = "0/0")]
        public string S2BuildingNum { get; set; }

        [Display(Name = "Województwo", Prompt = "Województwo")]
        public string S2Voivodship { get; set; }

        [Display(Name = "Powiat", Prompt = "Powiat")]
        [RegularExpression(@"^[a-zA-Z''-'\s]+['-'a-zA-Z''Ą''ą''ć''Ć''ę''Ę''Ó''ó''Ź''ź''Ż''ż''ń''Ń''ł''Ł''\'\s]{1,40}$",
         ErrorMessage = "Nie poprawny format, element może używać jedynie znaków a-ż A-Ż. max=40 znaków")]
        public string S2County { get; set; }

        [Display(Name = "Obywatelstwo", Prompt = "Obywatelstwo")]
        public string S2Country { get; set; }

        [Display(Name = "NIP", Prompt = "000-00-00-000")]
        [RegularExpression(@"^[0-9-]*$",
        ErrorMessage = "Niepoprawny format, NIP składa się jedynie z cyfr, np. 0123456789 lub 123-456-78-19")]
        public string S2NIP { get; set; }

        [Display(Name = "PESEL", Prompt = "00000000000")]
        [RegularExpression(@"^[0-9]*$",
        ErrorMessage = "Niepoprawny format, PESEL składa się jedynie z cyfr")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Numer PESEL musi składać się z 11 cyfr.")]
        public string S2PESEL { get; set; }

        [Display(Name = "Nr dowodu ", Prompt = "AAA000000")]
        [RegularExpression(@"^[0-9A-Z]*$",
        ErrorMessage = "Niepoprawny format, nr dowodu osobistego składa się z 3 liter i z 6 cyfr np. ABC123456")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Numer dowodu osobistego musi składać się z 9 znakow np. ABC123456.")]
        public string S2IdentityNum { get; set; }

        [Display(Name = "E-mail", Prompt = "przyklad@email.com")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Niepoprawny format, przyklad@mail.com",
        ErrorMessageResourceName = "Niepoprawny format, przyklad@mail.com")]
        public string S2Mail { get; set; }

        [Display(Name = "tel. stacjonarny", Prompt = "+00-00-000-00-00")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Nieprawidłowy format")]
        public string S2TelHomeNum { get; set; }

        [Display(Name = "tel. komórkowy", Prompt = "+00-000-000-000")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Nieprawidłowy format")]
        public string S2TelCell { get; set; }

        [Display(Name = "KRS", Prompt = "0000000000")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Numer KRS musi składać się z 10 cyfr.")]
        [RegularExpression(@"^[0-9]*$",
        ErrorMessage = "Niepoprawny format, KRS składa się jedynie z cyfr")]
        public string S2KRS { get; set; }

        [Display(Name = "REGON", Prompt = "0000000000")]
        public string S2REGON { get; set; }



    }
}
