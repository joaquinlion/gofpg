using GoFpg.API.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoFpg.API.Data
{
    public class DataContext : IdentityDbContext<User, UserRole, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Detail> Details { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclePhoto> VehiclePhotos { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<GlassType> GlassTypes { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<InsuranceClaim> InsuranceClaims { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehicle>().HasIndex(x => x.Tag).IsUnique();
            modelBuilder.Entity<Procedure>().HasIndex(x => x.ProcedureCode).IsUnique();
            modelBuilder.Entity<Part>().HasIndex(x => x.PartNo).IsUnique();
            modelBuilder.Entity<GlassType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Quote>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<InsuranceCompany>().HasIndex(x => x.InsCompany).IsUnique();
            modelBuilder.Entity<InsuranceClaim>().HasIndex(x => x.Id).IsUnique();
            //modelBuilder.Entity<User>(typeBuilder =>
            //{
            //    typeBuilder.HasMany(host => host.InsuranceClaims)
            //        .WithOne(guest => guest.User)
            //        .HasForeignKey(guest => guest.Id)
            //        .IsRequired();
            //});
            //modelBuilder.Entity<InsuranceClaim>(typeBuilder =>
            //{
            //    typeBuilder.HasOne(guest => guest.User)
            //        .WithMany(host => host.InsuranceClaims)
            //        .HasForeignKey(guest => guest.Id)
            //        .IsRequired();
            //});
            modelBuilder.Entity<Detail>().Property(p => p.LaborPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Detail>().Property(p => p.SparePartsPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Procedure>().Property(p => p.Price).HasColumnType("decimal(18,4)");

        }

        public DbSet<GoFpg.API.Models.NewClaimViewModel> NewClaimViewModel { get; set; }
    }
}
