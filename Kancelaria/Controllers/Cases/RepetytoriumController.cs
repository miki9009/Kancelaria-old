using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Kancelaria.Data;
using Kancelaria.Models;
using Kancelaria.Models.Cases;

namespace Kancelaria.Controllers.Cases
{
    [Authorize]
    public class RepetytoriumController : Controller
    {       
        public static void AddIfEmpty(Case @case, ApplicationDbContext _context)
        {
            if (@case.repetytorium == null)
            {
                var repetytorium = new Repetytorium() { CaseID = @case.ID };
                _context.Repetytoriums.Add(repetytorium);
                _context.SaveChanges();
                repetytorium.caseRemark = new List<CaseRemark>();
                @case.repetytorium = repetytorium;
            }
        }
    }
}