using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kancelaria.Data;
using Kancelaria.Models.Cases;
using Kancelaria.Models;

namespace Kancelaria.Controllers.Cases
{
    public class BasicsController : Controller
    {
        public static void AddIfEmpty(Case @case, ApplicationDbContext _context)
        {
            if (@case.basic == null)
            {
                var basic = new Basic() { CaseID = @case.ID };
                _context.Basics.Add(basic);
                _context.SaveChanges();
                @case.basic = basic;
            }
        }
    }
}