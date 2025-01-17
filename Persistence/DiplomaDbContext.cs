using Application.Interfaces;
using Domain;
using Persistence.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class WebDbContext(DbContextOptions<WebDbContext> options) : IdentityDbContext<IdentityUser>(options), IWebDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
