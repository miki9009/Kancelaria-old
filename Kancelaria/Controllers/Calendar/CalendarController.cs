using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kancelaria.Data;
using Microsoft.AspNetCore.Authorization;
using Kancelaria.Models.Calendar;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Kancelaria.Models;

namespace Kancelaria.Controllers
{
   
    [Authorize]
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext _context;
        bool updated = false;

        public CalendarController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        private string UserID()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            return claim.Value;
        }

        public IActionResult Index(int id, int year)
        {
            Calendar calendar = new Calendar();
            string thisId = UserID();


            calendar.month = id == 0 ? DateTime.Today.Month : id;

            calendar.year = id == 0 ? calendar.year : year;
            calendar.events = _context.Calendars.Where(o => (o.eventIndex == thisId && calendar.month == o.Month)).ToList();
            calendar.events.Sort(new CalendarSort());

            if (calendar.month > 12)
            {
                calendar.month = 1;
                calendar.year++;
            }
            else if(calendar.month < 1)
            {
                calendar.month = 12;
                calendar.year--;
            }
            calendar.firstDayIndex = calendar.GetFirstDayIndex(calendar.year, calendar.month);


            return View(calendar);
        }

        class CalendarSort : IComparer<Calendar>
        {
            public int Compare(Calendar x, Calendar y)
            {
                if (x.day > y.day)
                {
                    return 1;
                }
                else if (x.day < y.day)
                {
                    return -1;
                }
                else
                {
                    if (x.hour > y.hour)
                    {
                        return 1;
                    }
                    else if(x.hour < y.hour)
                    {
                        return -1;
                    }
                    else
                    {
                        if (x.minute > y.minute)
                        {
                            return 1;
                        }
                        else if (x.minute < y.minute)
                        {
                            return -1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }       
            }
        }


        //DODANIE ZADANIA ZE STRONY KALENDARZA
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id,Calendar calendar)
        {
            AddEvent(calendar);
            await _context.SaveChangesAsync();
            if (updated)
            {
                TempData["EventUpdated"] = true;
            }
            else
            {
                TempData["EventCreated"] = true;
            }
            return RedirectToAction("Index");
        }

        //DODANIE PRZEKAZANEGO CALENDAR TO ZADAŃ
        private void AddEvent(Calendar calendar)
        {
            calendar.eventIndex = UserID();
            calendar.Hour = int.Parse(calendar.eventTime.Substring(0, 2));
            calendar.Minute = int.Parse(calendar.eventTime.Substring(3, 2));
            calendar.Year = int.Parse(calendar.startDate.Substring(0, 4));
            calendar.Month = int.Parse(calendar.startDate.Substring(5, 2));
            calendar.Day = int.Parse(calendar.startDate.Substring(8, 2));
            if (calendar.characteristics == null || calendar.characteristics == "") { calendar.characteristics = " "; }
            bool exists = _context.Calendars.Any(o => o.ID == calendar.ID);
            if (exists)
            {
                updated = true;
                _context.Calendars.Update(calendar);
            }
            else
            {
                updated = false;
                _context.Calendars.Add(calendar);
            }
        }

        //USUNIĘCIE ZADANIA
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var calendar = await _context.Calendars.SingleOrDefaultAsync(m => m.ID == id);
                _context.Calendars.Remove(calendar);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return NotFound();
            }
            TempData["EventDeleted"] = true;
            return RedirectToAction("Index");
        }

        //DODANIE ZADANIA Z CONTROLLERA CASE////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task AddEventFromCase(Case _case)
        {

            List<Calendar> calendars = new List<Calendar>() 
            {
                //POZEW I INSTANCJA
                new Calendar(){ eventTime = _case.repetytorium.SummonsTime1, startDate = _case.repetytorium.SummonsDate1, characteristics = _case.repetytorium.RemarkSummons1, eventName = "Rozprawa I: "+_case.Name + " I instancji", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_s1") },
                new Calendar(){ eventTime = _case.repetytorium.SummonsTime2, startDate = _case.repetytorium.SummonsDate2, characteristics = _case.repetytorium.RemarkSummons2, eventName = "Rozprawa II: "+_case.Name + " I instancji", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_s2") },
                new Calendar(){ eventTime = _case.repetytorium.SummonsTime3, startDate = _case.repetytorium.SummonsDate3, characteristics = _case.repetytorium.RemarkSummons3, eventName = "Rozprawa III: "+_case.Name + " I instancji", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_s3") },
                new Calendar(){ eventTime = _case.repetytorium.SummonsTime4, startDate = _case.repetytorium.SummonsDate4, characteristics = _case.repetytorium.RemarkSummons4, eventName = "Rozprawa IV: "+_case.Name + " I instancji", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_s4") },
                new Calendar(){ eventTime = _case.repetytorium.SummonsTime5, startDate = _case.repetytorium.SummonsDate5, characteristics = _case.repetytorium.RemarkSummons5, eventName = "Rozprawa V: "+_case.Name + " I instancji", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_s5") },
                //APELACJA II INSTANCJI
                new Calendar(){ eventTime = _case.repetytorium.JudmentSummonsTime1, startDate = _case.repetytorium.JudmentSummonsDate1, characteristics = _case.repetytorium.JudmentRemarkSummons1, eventName = "Rozprawa I: "+_case.Name + " ", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o1") },
                new Calendar(){ eventTime = _case.repetytorium.JudmentSummonsTime2, startDate = _case.repetytorium.JudmentSummonsDate2, characteristics = _case.repetytorium.JudmentRemarkSummons2, eventName = "Rozprawa II: "+_case.Name + " I instancji", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o2") },
                new Calendar(){ eventTime = _case.repetytorium.JudmentSummonsTime3, startDate = _case.repetytorium.JudmentSummonsDate3, characteristics = _case.repetytorium.JudmentRemarkSummons3, eventName = "Rozprawa III: "+_case.Name + " I instancji", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o3") },
                new Calendar(){ eventTime = _case.repetytorium.JudmentSummonsTime4, startDate = _case.repetytorium.JudmentSummonsDate4, characteristics = _case.repetytorium.JudmentRemarkSummons4, eventName = "Rozprawa IV: "+_case.Name + " I instancji", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o4") },
                new Calendar(){ eventTime = _case.repetytorium.JudmentSummonsTime5, startDate = _case.repetytorium.JudmentSummonsDate5, characteristics = _case.repetytorium.JudmentRemarkSummons5, eventName = "Rozprawa V: "+_case.Name + " I instancji", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o5") },
                //ORZECZENIE I INSTANCJI
                new Calendar(){ eventTime = _case.repetytorium.AppealSummonsTime1, startDate = _case.repetytorium.AppealSummonsDate1, characteristics = _case.repetytorium.AppealRemarkSummons1, eventName = "Rozprawa I: "+_case.Name + " apelacja", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o1") },
                new Calendar(){ eventTime = _case.repetytorium.AppealSummonsTime2, startDate = _case.repetytorium.AppealSummonsDate2, characteristics = _case.repetytorium.AppealRemarkSummons2, eventName = "Rozprawa II: "+_case.Name + " apelacja", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o2") },
                new Calendar(){ eventTime = _case.repetytorium.AppealSummonsTime3, startDate = _case.repetytorium.AppealSummonsDate3, characteristics = _case.repetytorium.AppealRemarkSummons3, eventName = "Rozprawa III: "+_case.Name + " apelacja", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o3") },
                new Calendar(){ eventTime = _case.repetytorium.AppealSummonsTime4, startDate = _case.repetytorium.AppealSummonsDate4, characteristics = _case.repetytorium.AppealRemarkSummons4, eventName = "Rozprawa IV: "+_case.Name + " apelacja", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o4") },
                new Calendar(){ eventTime = _case.repetytorium.AppealSummonsTime5, startDate = _case.repetytorium.AppealSummonsDate5, characteristics = _case.repetytorium.AppealRemarkSummons5, eventName = "Rozprawa V: "+_case.Name + " apelacja", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o5") },
                 //Skarga kasacyjna
                new Calendar(){ eventTime = _case.repetytorium.CassationSummonsTime1, startDate = _case.repetytorium.CassationSummonsDate1, characteristics = _case.repetytorium.CassationRemarkSummons1, eventName = "Rozprawa I: "+_case.Name + " skarga kasacyjna", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o1") },
                new Calendar(){ eventTime = _case.repetytorium.CassationSummonsTime2, startDate = _case.repetytorium.CassationSummonsDate2, characteristics = _case.repetytorium.CassationRemarkSummons2, eventName = "Rozprawa II: "+_case.Name + " skarga kasacyjna", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o2") },
                new Calendar(){ eventTime = _case.repetytorium.CassationSummonsTime3, startDate = _case.repetytorium.CassationSummonsDate3, characteristics = _case.repetytorium.CassationRemarkSummons3, eventName = "Rozprawa III: "+_case.Name + " skarga kasacyjna", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o3") },
                new Calendar(){ eventTime = _case.repetytorium.CassationSummonsTime4, startDate = _case.repetytorium.CassationSummonsDate4, characteristics = _case.repetytorium.CassationRemarkSummons4, eventName = "Rozprawa IV: "+_case.Name + " skarga kasacyjna", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o4") },
                new Calendar(){ eventTime = _case.repetytorium.CassationSummonsTime5, startDate = _case.repetytorium.CassationSummonsDate5, characteristics = _case.repetytorium.CassationRemarkSummons5, eventName = "Rozprawa V: "+_case.Name + " skarga kasacyjna", eventIndex = _case.UserId, CaseID = string.Format("{0}_{1}", _case.ID, "_o5") }
            };
            foreach(Calendar calendar in calendars)
            {
                if (calendar.startDate != null && calendar.eventTime != null)
                {
                    await AddEventCaseAsync(calendar);
                }
            }
            await _context.SaveChangesAsync();
        }

        //Dodawanie lub aktualizacja zadań ze sprawy
        private async Task AddEventCaseAsync(Calendar calendar)
        {
            calendar.eventIndex = calendar.eventIndex == null ? UserID() : calendar.eventIndex;
            calendar.Hour = int.Parse(calendar.eventTime.Substring(0, 2));
            calendar.Minute = int.Parse(calendar.eventTime.Substring(3, 2));
            calendar.Year = int.Parse(calendar.startDate.Substring(0, 4));
            calendar.Month = int.Parse(calendar.startDate.Substring(5, 2));
            calendar.Day = int.Parse(calendar.startDate.Substring(8, 2));
            Calendar c = await GetIDAsync(calendar);
            if (c != null)
            {
                c.eventIndex = calendar.eventIndex;
                c.Hour = calendar.Hour;
                c.Minute = calendar.Minute;
                c.Year = calendar.Year;
                c.Month = calendar.Month;
                c.Day = calendar.Day;
                c.characteristics = calendar.characteristics;
                c.eventName = calendar.eventName;
                c.CaseID = calendar.CaseID;
                c.eventTime = calendar.eventTime;
                _context.Calendars.Update(c);
            }
            else
            {
                _context.Calendars.Add(calendar);
            }
        }

        private async Task<Calendar> GetIDAsync(Calendar calendar)
        {
            return await _context.Calendars.SingleOrDefaultAsync(o => o.CaseID == calendar.CaseID);
        }
    }
}