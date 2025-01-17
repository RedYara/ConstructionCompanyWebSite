using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IWebDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Building> Buildings { get; set; }
        DbSet<GroupType> GroupTypes { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
