using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kancelaria.Data;
using Kancelaria.Models;
using Microsoft.AspNetCore.Authorization;

namespace Kancelaria.Controllers.Cases
{
    [Authorize]
    public class ParticipantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public static void AddParticipant(int id, ApplicationDbContext _context)
        {
            _context.Participants.Add(new Participant() { CaseID = id });
            _context.SaveChanges();
        }

        public IActionResult RemoveParticipant(int id, int id2)
        {     
            _context.Participants.Remove(new Participant() { ID = id });
            _context.SaveChanges();
            id = id2;
            return RedirectToAction("Edit", "Cases", new { id, varover = "participants"});
        }
    }
}