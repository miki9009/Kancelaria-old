using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models.Cases
{
    public class MotorClaim
    {
        public ICollection<MotorClaim> motorClaims { get; set; }
        public int MotorClaimID { get; set; }
        public int CaseID { get; set; }

        [Display(Name = "Czy zgłoszono szkodę?")]
        public bool MotorSzkodaZgloszona { get; set; }

        [Display(Name = "Umowa przelewu wierzytelności")]
        public bool MotorUmowaPrzelewuWierzytelnosci { get; set; }

        [Display(Name = "Data zgłoszenia szkody")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataZgloszeniaSzkody { get; set; }

        [Display(Name = "Data szkody")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotroDataSzkody { get; set; }

        [Display(Name = "Numer szkody")]
        public string MotorNumerSzkody { get; set; }

        [Display(Name = "Zaliczka na biegłego (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorZaliczkaNaBieglego { get; set; }

        [Display(Name = "Dane pojazdu")]
        public string MotorDanePojazdu { get; set; }

        [Display(Name ="Rodzaj szkody")]
        public int MotorRodzajSzkody { get; set; }


        public bool MotorInformacjeOzawartejUgodzie { get; set; }

        [Display(Name = "Wartość przedmiotu sporu (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorWartoscPrzedmiotuSporu { get; set; }

        [Display(Name = "Opłata od pozwu (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorOplataOdPozwu { get; set; }

        [Display(Name = "Wezwanie do zapłaty (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorWezwanieDoZaplaty { get; set; }

        [Display(Name = "Data wezwania do zapłaty")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataWezwaniaDoZaplaty { get; set; }

        [Display(Name = "Data wniesienia pozwu")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataWniesieniaPozwu { get; set; }

        [Display(Name = "Data wydania nakazu zapłaty")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataWydaniaNakazuZaplaty { get; set; }

        [Display(Name = "Odpowiedź na sprzeciw")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorOdpowiedzNaSprzeciw { get; set; }

        [Display(Name = "Data odbioru sprzeciwu")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataOdbioruSprzeciwu { get; set; }

        [Display(Name = "Data początkowa naliczania odsetek")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataPoczatkowaNaliczaniaOdsetek { get; set; }

        [Display(Name = "Data ypłaconego odszkodowania")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataWysokoscWplaconegoOdszkodowania { get; set; }


        [Display(Name = "Wysokość wypłaconego odszkodowania", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorWysokoscWplaconegoOdszkodowania { get; set; }

        [Display(Name = "Kalkulacja naprawy wykonana na zlecenie pozwanego")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataKalkulacjaNaprawyPozwanego { get; set; }
        [Display(Name = "Kalkulacja naprawy wykonana na zlecenie pozwanego", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorKalkulacjaNaprawyPozwanego { get; set; }

        [Display(Name = "Kalkulacja naprawy wykonana na zlecenie powoda")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataKalkulacjaNaprawyPowoda { get; set; }
        [Display(Name = "Kalkulacja naprawy wykonana na zlecenie powoda", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorKalkulacjaNaprawyPowoda { get; set; }

        [Display(Name = "Wycena wartości pojazdu wykonana na zlecenie powzwanego")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataWartoscNaprawyPozwanego { get; set; }
        [Display(Name = "Wycena wartości pojazdu wykonana na zlecenie powzwanego", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorWartoscNaprawyPozwanego { get; set; }

        [Display(Name = "Wartość naprawy wykonana na zlecenie powoda")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataWartoscNaprawyPowoda{ get; set; }
        [Display(Name = "Wartość naprawy wykonana na zlecenie powoda", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorWartoscNaprawyPowoda { get; set; }

        [Display(Name = "Wycena wartości pojazdu wykonana na zlecenie powoda")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataWycenaWartosciPojazduPowoda { get; set; }
        [Display(Name = "Wycena wartości pojazdu wykonana na zlecenie powoda", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorWycenaWartosciPokazduPowoda { get; set; }

        [Display(Name = "Potwierdzenie realizacji przelewu")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataPotwierdzenieRealizacjiPrzelewu { get; set; }
        [Display(Name = "Kwota (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorPotwierdzenieRealizacjiPrzelewu { get; set; }

        [Display(Name = "Faktura VAT za naprawę pojazdu")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataFakturaVATNaprawaPojazdu { get; set; }
        [Display(Name = "Kwota (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorFakturaVatNaprawaPojazdu { get; set; }

        public bool MotorUmowaNajmuSamochoduZastepczego { get; set; }

        [Display(Name = "Faktura VAT za najem pojazdu zastępczego")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataFakturaVATNajemPojazduZastepczego { get; set; }
        [Display(Name = "Kwota (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorFakturaVATNajemPojazduZastepczego { get; set; }

        [Display(Name = "Faktura VAT za kalkulacje kosztów naprawy")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string MotorDataFakturaVATKalkulacjeKosztowNaprawy { get; set; }

        [Display(Name = "Kwota (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal MotorFakturaVATKalkulacjeKosztowNaprawy { get; set; }
    }
}
