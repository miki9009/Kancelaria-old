using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Kancelaria.Models;
using Kancelaria.Models.Cases;
using Kancelaria.Models.Calendar;

namespace Kancelaria.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Case> Cases { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Basic> Basics { get; set; }
        public DbSet<Repetytorium> Repetytoriums { get; set; }
        public DbSet<MotorClaim> MotorClaims { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<KancelariaUser> KancelariaUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
