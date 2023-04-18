using Diploma.Application.Interfaces;
using Diploma.Domain;
using Diploma.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Persistence
{
    public class DiplomaDbContext : DbContext, IDiplomaDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DiplomaDbContext(DbContextOptions<DiplomaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
