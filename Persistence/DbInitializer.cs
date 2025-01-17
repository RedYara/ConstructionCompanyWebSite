using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DbInitializer
    {
        public static async Task Initialize(WebDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            dbContext.Database.EnsureCreated();
            await dbContext.Database.MigrateAsync();

        }
    }
}
