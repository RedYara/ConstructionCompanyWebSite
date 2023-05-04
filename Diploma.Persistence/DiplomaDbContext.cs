﻿using Diploma.Application.Interfaces;
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
        public DbSet<House> Houses { get; set; }
        public DbSet<Bath> Baths { get; set; }
        public DiplomaDbContext(DbContextOptions<DiplomaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
