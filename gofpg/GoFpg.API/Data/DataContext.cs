using GoFpg.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoFpg.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehicleType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Procedure>().HasIndex(x => x.Description).IsUnique();
        }
    }
}
