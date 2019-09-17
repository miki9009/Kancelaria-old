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
    public class MotorClaims : Controller
    {
        public static void AddIfEmpty(Case @case, ApplicationDbContext _context)
        {
            if (@case.motorClaim == null)
            {
                var motorClaims = new MotorClaim() { CaseID = @case.ID };
                _context.MotorClaims.Add(motorClaims);
                _context.SaveChanges();
                @case.motorClaim = motorClaims;
            }
        }
    }
}