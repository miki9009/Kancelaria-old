using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kancelaria.Data;
using Kancelaria.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Kancelaria.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var list = await _context.Notifications.Where(o => o.UserID == UserID()).ToListAsync<Notification>();
            var model = new Notification()
            {
                currentNotifications = list
            };

            bool[] views = new bool[list.Count];

            for (int i = 0; i < model.currentNotifications.Count; i++) //Zmiana wiadomoœci na odczytane i przypisanie indeksów nieodczytanych
            {
                views[i] = list[i].Viewed;
                list[i].Viewed = true;
            }

            IEnumerable<Notification> numerable = list.AsEnumerable();
             _context.Notifications.UpdateRange(numerable);
            await _context.SaveChangesAsync();

            for (int i = 0; i < model.currentNotifications.Count; i++) //przypisanie modelowi nieodczytanych wiadomosci po zapisaniu juz zmian do bazy danych
            {
                model.currentNotifications[i].Viewed = views[i];
            }

            return View(model);

        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .SingleOrDefaultAsync(m => m.ID == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // GET: Notifications/Create
        public IActionResult Create()
        {
            var model = new Notification()
            {
                UserID = UserID(),
                From = this.User.Identity.Name
        };
            return View(model);
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Body,UserID,DateCreated,Viewed,From,To")] Notification notification)
        {           
            if (ModelState.IsValid)
            {
                string login;
                try
                {
                    login = _context.Users.SingleOrDefault(o => o.UserName == notification.To).Id;
                }
                catch
                {
                    login = null;
                    ViewData["Title"] = "Adres odbiorcy jest nieprawid³owy.";
                }
                if (login != null)
                {
                    notification.DateCreated = DateTime.Now.ToString();
                    notification.UserID = login;
                    _context.Add(notification);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                
            }
            return View(notification);
        }

        // GET: Notifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications.SingleOrDefaultAsync(m => m.ID == id);
            if (notification == null)
            {
                return NotFound();
            }
            return View(notification);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Body,UserID,DateCreated,Viewed")] Notification notification)
        {
            
            if (id != notification.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(notification.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(notification);
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications.SingleOrDefaultAsync(m => m.ID == id);
            if (notification.UserID == UserID())
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        private bool NotificationExists(int id)
        {
            return _context.Notifications.Any(e => e.ID == id);
        }

        private string UserID()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            return claim.Value;
        }

    }


}
