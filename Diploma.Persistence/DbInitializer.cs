using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(DiplomaDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
