using Diploma.Application.Interfaces;
using Diploma.Domain;
using Diploma.Persistence.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Persistence
{
    public class DiplomaDbContext : IdentityDbContext<IdentityUser>, IDiplomaDbContext
    {
        public DbSet<Order> Orders { get; set; }
        //public DbSet<House> Houses { get; set; }
        //public DbSet<Bath> Baths { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DiplomaDbContext(DbContextOptions<DiplomaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
