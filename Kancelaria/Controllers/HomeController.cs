using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kancelaria.Models.Admin;
using Kancelaria.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Kancelaria.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading;
using Kancelaria.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Kancelaria.Controllers
{
    
    //[RequireHttps]
    public class HomeController : Controller
    {
        private const string POST_PATH = @"\html";
        public readonly ApplicationDbContext _context;
        IHostingEnvironment HostingEnvironment { get; }

        public HomeController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            HostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            Notification model = new Notification();
            ViewData["Posts"] = GetAllPosts();
            if (this.User.Identity.IsAuthenticated)
            {
                await Task.Run(() =>
                {
                    List<Notification> list = _context.Notifications.Where(n => n.UserID == UserID() && !n.Viewed).ToList<Notification>();
                    model.currentNotifications = list;
                });
            }

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        private string UserID()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            return claim.Value;
        }

        string[] GetAllPosts()
        {
            string path = HostingEnvironment.WebRootPath + POST_PATH;
            if (Directory.Exists(path))
            {
                string[] paths = Directory.GetFiles(path);
                try
                {
                    for (int i = 0; i < paths.Length; i++)
                    {
                        paths[i] = Path.GetFileName(paths[i]);
                    }
                }
                catch
                {
                    return null;
                }
                return paths;
            }
        return null;
        }
    }
}
