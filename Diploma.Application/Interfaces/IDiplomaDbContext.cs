using Diploma.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.Interfaces
{
    public interface IDiplomaDbContext
    {
        DbSet<Order> Orders { get;set; }
        Task<int> SaveChangesAsync (CancellationToken cancellationToken);
    }
}
