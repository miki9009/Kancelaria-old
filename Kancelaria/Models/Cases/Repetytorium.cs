using Kancelaria.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models.Cases
{
    public class Repetytorium
    {
        public ICollection<Repetytorium> repetytoriums { get; set; }

        public List<CaseRemark> caseRemark;
        public int ID { get; set; }
        public int CaseID { get; set; }

        //WARTOŚC ROSZCZENIA I WEZWANIE DO ZAPŁATY

        [Display(Name = "Dokumenty")]
        public bool Documents { get; set; }

        [Display(Name = "Ewidencja")]
        public bool Record { get; set; }

        [Display(Name = "Wysokość roszczenia (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal Value1 { get; set; }

        [Display(Name = "Wartość aktualna (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal Value2 { get; set; }

        [Display(Name = "Wysokość akt. przedmiotu sporu (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal Value3 { get; set; }

        //Wezwanie przesądowe do zapłaty
        [Display(Name = "Wezwanie przedsądowe do zapłaty (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal Value4 { get; set; }

        [Display(Name = "Data odbioru")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string Date1 { get; set; }

        [Display(Name = "Uwagi")]
        public string Remark1 { get; set; }

        //POZEW

        [Display(Name = "Nazwa sądu")]
        public string CourtName { get; set; }

        [Display(Name = "Stwierdzona prawomocność orzeczenia")]
        public bool Boolean2 { get; set; }

        [Display(Name = "Data wysłania pozwu")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string Date2 { get; set; }

        [Display(Name = "Data odbioru pozwu")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string Date3 { get; set; }

        [Display(Name = "Opłaty dokonał")]
        public int Integer1 { get; set; }

        [Display(Name = "Koszty zastępowe wnioskowane (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal Value5 { get; set; }

        [Display(Name = "Koszty procesu dodatkowe (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal Value6 { get; set; }

        //Sprawy pozew


        [Display(Name = "Data rozprawy I")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string SummonsDate1 { get; set; }

        
        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string SummonsTime1 { get; set; }

        [Display(Name = "Data rozprawy II")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string SummonsDate2 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string SummonsTime2 { get; set; }

        [Display(Name = "Data rozprawy III")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string SummonsDate3 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string SummonsTime3 { get; set; }

        [Display(Name = "Data rozprawy IV")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string SummonsDate4 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string SummonsTime4 { get; set; }

        [Display(Name = "Data rozprawy V")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string SummonsDate5 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string SummonsTime5 { get; set; }

        [Display(Name = "Uwagi")]
        public string RemarkSummons1 { get; set; }

        [Display(Name = "Uwagi")]
        public string RemarkSummons2 { get; set; }

        [Display(Name = "Uwagi")]
        public string RemarkSummons3 { get; set; }

        [Display(Name = "Uwagi")]
        public string RemarkSummons4 { get; set; }

        [Display(Name = "Uwagi")]
        public string RemarkSummons5 { get; set; }

        //Orzeczenie I instancji

        [Display(Name = "Nazwa sądu")]
        public string JudgmentCourtName { get; set; }

        [Display(Name = "Prawomocność wyroku")]
        public bool JudgmentPrawomocnosc { get; set; }

        [Display(Name = "Data wydania nakazu zapłaty")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudgmentDataWydaniaNakazuZaplaty { get; set; }

        [Display(Name = "Data odbioru nakazu zapłaty")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudgmentDataOdbioruNakazuZaplaty { get; set; }


        public int JudgmentNakazZaplaty { get; set; }

        public int JudgmentOrzeczenie { get; set; }

        public int JudgmentOplatyDokonal { get; set; }

        [Display(Name = "Data wysłania (sprzeciw/zarzut)")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudgmentDataWyslaniaSprzeciwu { get; set; }

        [Display(Name = "Data wysłania (wyrok)")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudgmentDataWyslaniaWyrok { get; set; }


        [Display(Name = "Data odbioru (sprzeciw/zarzut)")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudgmentDataOdbioruSprzeciw { get; set; }


        [Display(Name = "Data odbioru (wyrok)")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudgmentDataOdbioruWyrok { get; set; }

        [Display(Name = "Koszty procesu przyznane (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal JudgmentKosztyProcesuPrzyznane { get; set; }

        [Display(Name = "Odpowiedź na sprzeciw od nakazu zapłaty")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudgmentDataSprzeciwNakazuZaplaty { get; set; }


        [Display(Name = "Koszty zastępstwa przyznane (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal JudgmentKosztyZastepstwaPrzyznane { get; set; }

        [Display(Name = "Wysokość opłaty (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal JudgmentWysokoscOplaty { get; set; }

        [Display(Name = "Data dokonania opłaty")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudgmentDataDokonaniaOplaty { get; set; }


        

        [Display(Name = "Data rozprawy I")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudmentSummonsDate1 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string JudmentSummonsTime1 { get; set; }

        [Display(Name = "Data rozprawy II")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudmentSummonsDate2 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string JudmentSummonsTime2 { get; set; }

        [Display(Name = "Data rozprawy III")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudmentSummonsDate3 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string JudmentSummonsTime3 { get; set; }

        [Display(Name = "Data rozprawy IV")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudmentSummonsDate4 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string JudmentSummonsTime4 { get; set; }

        [Display(Name = "Data rozprawy V")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string JudmentSummonsDate5 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string JudmentSummonsTime5 { get; set; }

        [Display(Name = "Uwagi")]
        public string JudmentRemarkSummons1 { get; set; }

        [Display(Name = "Uwagi")]
        public string JudmentRemarkSummons2 { get; set; }

        [Display(Name = "Uwagi")]
        public string JudmentRemarkSummons3 { get; set; }

        [Display(Name = "Uwagi")]
        public string JudmentRemarkSummons4 { get; set; }

        [Display(Name = "Uwagi")]
        public string JudmentRemarkSummons5 { get; set; }

        public bool Summon1 { get; set; }
        public bool Summon2 { get; set; }
        public bool Summon3 { get; set; }
        public bool Summon4 { get; set; }
        public bool Summon5 { get; set; }

        public bool JudgmentSummon1 { get; set; }
        public bool JudgmentSummon2 { get; set; }
        public bool JudgmentSummon3 { get; set; }
        public bool JudgmentSummon4 { get; set; }
        public bool JudgmentSummon5 { get; set; }

        public bool Jugdment { get; set; }

        //APELACJA II INSTANCJI
        public bool Appeal { get; set; }

        [Display(Name = "Nazwa sądu")]
        public string AppealCourtName { get; set; }

        [Display(Name = "Prawomocność wyroku")]
        public bool AppealPrawomocnosc { get; set; }

        [Display(Name = "Data wysłania apelacji")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string AppealDataWyslaniaApelacji { get; set; }

        [Display(Name = "Data odbioru apelacji")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string AppealDataOdbioruApelacji { get; set; }

        [Display(Name = "Koszty wnioskowane (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
         ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal AppealKosztyWnioskowane { get; set; }

        [Display(Name = "Koszty przyznane (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal AppealKosztyPrzyznane { get; set; }

        [Display(Name = "Data wyroku apelacyjnego")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string AppealDataWyrokuApelacyjnego { get; set; }

        [Display(Name = "Data opłaty")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string AppealDataOplaty { get; set; }


        [Display(Name = "Wysokość opłaty (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal AppealWysokoscOplaty { get; set; }

        public int AppealOplatyDokonal { get; set; } //Opłaty dokonał



        [Display(Name = "Data rozprawy I")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string AppealSummonsDate1 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string AppealSummonsTime1 { get; set; }

        [Display(Name = "Data rozprawy II")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string AppealSummonsDate2 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string AppealSummonsTime2 { get; set; }

        [Display(Name = "Data rozprawy III")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string AppealSummonsDate3 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string AppealSummonsTime3 { get; set; }

        [Display(Name = "Data rozprawy IV")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string AppealSummonsDate4 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string AppealSummonsTime4 { get; set; }

        [Display(Name = "Data rozprawy V")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string AppealSummonsDate5 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string AppealSummonsTime5 { get; set; }

        [Display(Name = "Uwagi")]
        public string AppealRemarkSummons1 { get; set; }

        [Display(Name = "Uwagi")]
        public string AppealRemarkSummons2 { get; set; }

        [Display(Name = "Uwagi")]
        public string AppealRemarkSummons3 { get; set; }

        [Display(Name = "Uwagi")]
        public string AppealRemarkSummons4 { get; set; }

        [Display(Name = "Uwagi")]
        public string AppealRemarkSummons5 { get; set; }

        public bool AppealSummon1 { get; set; }
        public bool AppealSummon2 { get; set; }
        public bool AppealSummon3 { get; set; }
        public bool AppealSummon4 { get; set; }
        public bool AppealSummon5 { get; set; }

        //Kasacja
        public bool Cassation { get; set; }

        [Display(Name = "Nazwa sądu")]
        public string CassationCourtName { get; set; }

        [Display(Name = "Prawomocność wyroku")]
        public bool CassationPrawomocnosc { get; set; }

        [Display(Name = "Data wysłania kasacji")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string CassationDataWyslaniaApelacji { get; set; }

        [Display(Name = "Data odbioru kasacji")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string CassationDataOdbioruApelacji { get; set; }

        [Display(Name = "Koszty wnioskowane (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
         ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal CassationKosztyWnioskowane { get; set; }

        [Display(Name = "Koszty przyznane (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal CassationKosztyPrzyznane { get; set; }

        [Display(Name = "Data kasacji")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string CassationDataWyrokuApelacyjnego { get; set; }

        [Display(Name = "Data opłaty")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string CassationDataOplaty { get; set; }


        [Display(Name = "Wysokość opłaty (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal CassationWysokoscOplaty { get; set; }

        public int CassationOplatyDokonal { get; set; } //Opłaty dokonał



        [Display(Name = "Data rozprawy I")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string CassationSummonsDate1 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string CassationSummonsTime1 { get; set; }

        [Display(Name = "Data rozprawy II")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string CassationSummonsDate2 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string CassationSummonsTime2 { get; set; }

        [Display(Name = "Data rozprawy III")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string CassationSummonsDate3 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string CassationSummonsTime3 { get; set; }

        [Display(Name = "Data rozprawy IV")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string CassationSummonsDate4 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string CassationSummonsTime4 { get; set; }

        [Display(Name = "Data rozprawy V")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string CassationSummonsDate5 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string CassationSummonsTime5 { get; set; }

        [Display(Name = "Uwagi")]
        public string CassationRemarkSummons1 { get; set; }

        [Display(Name = "Uwagi")]
        public string CassationRemarkSummons2 { get; set; }

        [Display(Name = "Uwagi")]
        public string CassationRemarkSummons3 { get; set; }

        [Display(Name = "Uwagi")]
        public string CassationRemarkSummons4 { get; set; }

        [Display(Name = "Uwagi")]
        public string CassationRemarkSummons5 { get; set; }

        public bool CassationSummon1 { get; set; }
        public bool CassationSummon2 { get; set; }
        public bool CassationSummon3 { get; set; }
        public bool CassationSummon4 { get; set; }
        public bool CassationSummon5 { get; set; }

        //Postępowanie klauzulowe

        public bool Clause { get; set; }

        [Display(Name = "Nazwa sądu")]
        public string ClauseCourtName { get; set; }

        public bool ClauseWniosekKlauzulaPrytwatnosci { get; set; }

        [Display(Name = "Data nadania")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ClauseDataNadania { get; set; }

        [Display(Name = "Data wysłania")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ClauseDataWyslania { get; set; }

        [Display(Name = "Data odbioru")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ClauseDataOdbioru { get; set; }


        public bool ClauseWniosekKlauzulaWykonalnosci { get; set; }

        [Display(Name = "Data wysłania")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ClauseDataWyslania2 { get; set; }

        [Display(Name = "Data nadania")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ClauseDataNadania2 { get; set; }

        [Display(Name = "Data odbioru")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ClauseDataOdbioru2 { get; set; }

        [Display(Name = "Wartość (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal ClauseWartosc { get; set; }


        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public int ClausePayment { get; set; }

        [Display(Name = "Koszty zastępstwa (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal ClauseKosztyZastepstwa { get; set; }

        [Display(Name = "Opłaty sądowe (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal ClauseOplatySadowe { get; set; }

        [Display(Name = "Data Rozprawy I")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ClauseSummonsDate1 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string ClauseSummonsTime1 { get; set; }

        [Display(Name = "Data rozprawy II")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ClauseSummonsDate2 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string ClauseSummonsTime2 { get; set; }

        [Display(Name = "Data rozprawy III")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ClauseSummonsDate3 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string ClauseSummonsTime3 { get; set; }

        [Display(Name = "Data rozprawy IV")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ClauseSummonsDate4 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string ClauseSummonsTime4 { get; set; }

        [Display(Name = "Data rozprawy V")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ClauseSummonsDate5 { get; set; }

        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public string ClauseSummonsTime5 { get; set; }

        [Display(Name = "Uwagi")]
        public string ClauseRemarkSummons1 { get; set; }

        [Display(Name = "Uwagi")]
        public string ClauseRemarkSummons2 { get; set; }

        [Display(Name = "Uwagi")]
        public string ClauseRemarkSummons3 { get; set; }

        [Display(Name = "Uwagi")]
        public string ClauseRemarkSummons4 { get; set; }

        [Display(Name = "Uwagi")]
        public string ClauseRemarkSummons5 { get; set; }

        public bool ClauseSummon1 { get; set; }
        public bool ClauseSummon2 { get; set; }
        public bool ClauseSummon3 { get; set; }
        public bool ClauseSummon4 { get; set; }
        public bool ClauseSummon5 { get; set; }

        //Postępowanie egzekuzyjne

        public bool Execution { get; set; }

        [Display(Name = "Nazwa/adres komornika")]
        public string ExecutionKomornikAdres { get; set; }

        [Display(Name = "Wniosek egzekucyjny")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ExecutionWniosek { get; set; }

        [Display(Name = "Wartość przedmiotu egzekucji (bez odsetek i kosztów)")]
        public string ExecutionWartoscPrzedmiotu { get; set; }

        [Display(Name = "Skierowanie do komornika")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ExecutionSkierowanieDoKomornika { get; set; }

        [Display(Name = "Koszty zastępstwa w egzekucji (wnioskowane) (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal ExecutionKosztyZastepstwa { get; set; }

        [Display(Name = "Koszty zastępstwa w egzekucji (zasądzone) (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal ExecutionKosztyZastepstwa2 { get; set; }

        [Display(Name = "Faktura netto (egzekucja) (PLN)", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal ExecutionFakturaNetto { get; set; }

        [Display(Name = "Data pierwszej licytacji")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ExecutionDataPierwszejLicytacji { get; set; }

        [Display(Name = "Data zawieszenia egzekucji")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ExecutionDataZawieszenia { get; set; }

        [Display(Name = "Data zakończenia egzekucji")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string ExecutionDataZakonczenia { get; set; }

        public int ExecutionRodzaj { get; set; }

        //Informacje o sprawie

        public bool InfoPelnomocnictwo { get; set; }
        
        public bool InfoUmowaPodpisana { get; set; }
        public bool InfoZwolnienieKosztow { get; set; }
        public bool InfoFormularzKosztow { get; set; }
        public bool InfoFormularzKosztowPodpisany { get; set; }
        public bool InfoFormularzDanych { get; set; }
        public bool InfoZwroconoDokumentyKlientowi { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format")]
        public string InfoZwroconoDokumentyData { get; set; }

        [Display(Name = "Opłacona faktura", Prompt = "000-00-0000")]
        public bool InfoOplaconaFaktura { get; set; }

        [Display(Name = "Numer faktury", Prompt = "000-00-0000")]
        public string InfoNumerFaktury { get; set; }

        [Display(Name = "Stawka za 1h (brutto) PLN", Prompt = "PLN 0,00")]
        [RegularExpression(@"^[0-9,]*$",
        ErrorMessage = "Niepoprawny format, wartość powinna zawierać same liczby, a reszta powinna być oddzielona przecinkiem 0,00")]
        public decimal InfoStawkaZaGodzine { get; set; }

        public string RozliczenieZklientem { get; set; }



        //DODATKOWE
        [Display(Name = "Dodatkowe", Prompt = "PLN 0,00")]
        public int Additional { get; set; }


    }
}
