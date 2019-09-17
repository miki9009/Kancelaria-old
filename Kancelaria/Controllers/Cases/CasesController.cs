using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kancelaria.Data;
using Kancelaria.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Kancelaria.Models.Cases;
using Kancelaria.Controllers.Cases;
using Kancelaria.Models.Calendar;
using Microsoft.AspNetCore.Hosting;

namespace Kancelaria.Controllers
{
    //[RequireHttps]
    [Authorize]
    public class CasesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CasesController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        private string UserID()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            return claim.Value;
        }

        // GET: Cases
        public async Task<IActionResult> Index()
        {
            return View(await Task.Run(() =>
            {
                return _context.Cases.Where(o => o.UserId == UserID());
            }));
        }

        // GET: Cases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cases/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Name,Pelnomocnik")] Case _case)
        {
            if (ModelState.IsValid)
            {
                _case.UserId = UserID();
                _context.Add(_case);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(_case);
        }

        // GET: Cases/Edit/5
        public async Task<IActionResult> Edit(int? id, string overlap)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _case = await _context.Cases.SingleOrDefaultAsync(m => m.ID == id);

            if (_case == null)
            {
                return NotFound();
            }

            if (_case.UserId != UserID())
            {
                return RedirectToAction("Index");
            }

            //Participants
            if (_context.Participants.Any())
            {
                var queryParticipants = _context.Participants.Where(o => o.CaseID == _case.ID);
                _case.participants = queryParticipants.ToList<Participant>();
            }
            else
            {
                _case.participants = new List<Participant>();
            }

            //Basic
            _case.basic = await _context.Basics.SingleOrDefaultAsync(b => b.CaseID == _case.ID);
            BasicsController.AddIfEmpty(_case, _context);

            //Repetytorium
            _case.repetytorium = await _context.Repetytoriums.SingleOrDefaultAsync(r => r.CaseID == _case.ID);
            RepetytoriumController.AddIfEmpty(_case, _context);

            //ADDITIONAL
            if (_case.repetytorium.Additional == 1)
            {
                _case.motorClaim = await _context.MotorClaims.SingleOrDefaultAsync(m => m.CaseID == _case.ID);
                
                MotorClaims.AddIfEmpty(_case, _context);
            }

            _case.overlap = overlap;
            overlap = null;
            
            return View(_case);
        }

        // POST: Cases/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Case _case, List<Participant> participants, MotorClaim motorClaim, Basic basic, Repetytorium repetytorium, string varover, string overlap)
        {
            if (id != _case.ID)
            {
                ViewData["Error"] = "Wyst¹pi³ b³¹d Nie zgadzaj¹ siê numery spraw.";
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _case.UserId = UserID();
                    _context.Update(_case);
                    _context.Basics.Update(basic);
                    if (motorClaim.CaseID == _case.ID)
                    {
                        _context.MotorClaims.Update(motorClaim);
                    }
                    _context.Repetytoriums.Update(repetytorium);
                    foreach(Participant participant in participants)
                    {
                        _context.Update(participant);
                    }
                    _case.repetytorium = repetytorium;
                    await new CalendarController(_context).AddEventFromCase(_case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!CaseExists(_case.ID))
                    {
                        ViewData["Error"] = ex.Message;
                        return View("Error");
                    }
                    else
                    {
                        ViewData["Error"] = ex.Message;
                        return View("Error");
                    }
                }
                id = _case.ID;

                if (overlap == null)
                {
                    overlap = varover;
                }

                if (overlap == "participants")
                {
                    ParticipantsController.AddParticipant(_case.ID, _context);
                }

                return RedirectToAction("Edit", new {id, overlap });
            }
            return View(_case);
        }

        // GET: Cases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _case = await _context.Cases.SingleOrDefaultAsync(m => m.ID == id);
            if (_case == null)
            {
                return NotFound();
            }

            return View(_case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var _case = await _context.Cases.SingleOrDefaultAsync(m => m.ID == id);
            _context.Cases.Remove(_case);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CaseExists(int id)
        {
            return _context.Cases.Any(e => e.ID == id);
        }

        //PDF
        public async Task<FileStreamResult> ReturnPDF(int id)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            var _case = await _context.Cases.SingleOrDefaultAsync(m => m.ID == id);
            _case.repetytorium = await _context.Repetytoriums.SingleOrDefaultAsync(r => r.CaseID == _case.ID);
            _case.basic = await _context.Basics.SingleOrDefaultAsync(b => b.CaseID == _case.ID);
            return new PDF().FromExistingPDF(_case, webRootPath);
        }

        //DOCX
        public FileResult Download()
        {
            var fileName = "\\Data\\template.docx";
            var filepath = _hostingEnvironment.WebRootPath+fileName;
            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "application/x-msdownload", "szablon.docx");
        }

    }


}
