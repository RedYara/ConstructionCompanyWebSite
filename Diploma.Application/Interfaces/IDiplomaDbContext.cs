using Diploma.Domain;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.Interfaces
{
    public interface IDiplomaDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<House> Houses { get; set; }
        DbSet<Bath> Baths { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Comment> Comments { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
