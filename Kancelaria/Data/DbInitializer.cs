
using System.Linq;
using Kancelaria.Models.Admin;


namespace Kancelaria.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext appContext)
        {
            appContext.Database.EnsureCreated();


        }
    }
}
