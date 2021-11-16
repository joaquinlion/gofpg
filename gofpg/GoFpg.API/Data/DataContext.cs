using GoFpg.API.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoFpg.API.Models;
using Microsoft.AspNetCore.Identity;

namespace GoFpg.API.Data
{
    public class DataContext : IdentityDbContext<User, UserRole, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclePhoto> VehiclePhotos { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<InsuranceClaim> InsuranceClaims { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<Dealership> Dealerships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehicle>().HasIndex(x => x.Plaque).IsUnique();
            modelBuilder.Entity<Brand>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<DocumentType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Procedure>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<VehicleType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<InsuranceCompany>().HasIndex(x => x.InsCompany).IsUnique();
            modelBuilder.Entity<InsuranceClaim>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Dealership>().HasIndex(x => x.Dealer).IsUnique();

        }

        public DbSet<GoFpg.API.Models.NewClaimViewModel> NewClaimViewModel { get; set; }
    }
}
