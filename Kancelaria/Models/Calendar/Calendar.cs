using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models.Calendar
{
    public class Calendar
    {
        public Calendar()
        {
            var dt = DateTime.Now;
            this.year = dt.Year;
            this.day = dt.Day;
            this.month = dt.Month;
            this.hour = dt.Hour;
            this.minute = dt.Minute;
        }
        public ICollection<Calendar> calendars { get; set; }
        public int ID { get; set; }
        
        public string eventIndex { get; set; }

        [JsonProperty(PropertyName = "event_name")]
        [Display(Name = "Nazwa zadania")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string eventName { get; set; }

        [JsonProperty(PropertyName = "event_time")]
        [Display(Name = "Godzina")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Time)]
        public string eventTime { get; set; }


        [JsonProperty(PropertyName = "event_description")]
        [Display(Name = "Opis zadania")]
        public string characteristics { get; set; }


        [Display(Name = "Dzień zadania")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = " ", NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public string startDate { get; set; }

        [JsonProperty(PropertyName = "event_year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "event_month")]
        public int Month { get; set; }

        [JsonProperty(PropertyName = "event_day")]
        public int Day { get; set; }

        [JsonProperty(PropertyName = "event_hour")]
        public int Hour { get; set; }

        [JsonProperty(PropertyName = "event_minute")]
        public int Minute { get; set; }

        public string CaseID { get; set; }

        public int day;
        public int month = 0;
        public int year;
        public int hour;
        public int minute;
        public int dayCurrent;

        public int firstDayIndex;
        public int lastDayIndex;

        public List<Calendar> events = new List<Calendar>();


       

        public string GetEventIndex(ref Calendar calendar)
        {

            return string.Format("{0:0000}{1:00}{2:00}{3:00}{4:00}", calendar.year, calendar.month, calendar.day, calendar.hour, calendar.minute);
        }


        public int GetDayIndex(int year, int month, int day)
        {
            while (month > 1)
            {
                day -= DateTime.DaysInMonth(DateTime.Today.Year, month);
                month--;
            }
            return day;
        }



        public int GetCurrentMonthDay()
        {
            return DateTime.Now.Day;
        }

        public int GetFirstDayIndex(int year, int month)
        {
            var firstDayOfMonth = new DateTime(year, month, 1).DayOfWeek;
            return (int)firstDayOfMonth == 0 ? 7 : (int)firstDayOfMonth;
        }

        public int GetLastDayIndex(int year, int month, int firstDayIndex)
        {
            return DateTime.DaysInMonth(year, month)+firstDayIndex;
        }

        public string GetMonth(int month)
        {
            string mnth;
            switch(month)
            {
                case 1:
                    mnth = "Styczeń";
                    break;
                case 2:
                    mnth = "Luty";
                    break;
                case 3:
                    mnth = "Marzec";
                    break;
                case 4:
                    mnth = "Kwiecień";
                    break;
                case 5:
                    mnth = "Maj";
                    break;
                case 6:
                    mnth = "Czerwiec";
                    break;
                case 7:
                    mnth = "Lipiec";
                    break;
                case 8:
                    mnth = "Sierpień";
                    break;
                case 9:
                    mnth = "Wrzesień";
                    break;
                case 10:
                    mnth = "Październik";
                    break;
                case 11:
                    mnth = "Listopad";
                    break;
                case 12:
                    mnth = "Grudzień";
                    break;
                default:
                    mnth = "Błąd";
                    break;
            }
            return mnth;
        }

        
    }
}
