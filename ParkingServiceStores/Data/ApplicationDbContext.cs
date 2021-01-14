using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingServiceStores.Data.Models;

namespace ParkingServiceStores.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarOwner> CarOwners { get; set; }
        public virtual DbSet<JournalRecord> Journal { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Debt> Debts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .HasOne(c => c.Owner)
                .WithOne(o => o.Car)
                .HasForeignKey<CarOwner>(o => o.CarId);

            builder.Entity<Car>()
                .HasMany(c => c.JournalRecords)
                .WithOne(r => r.Car)
                .HasForeignKey(r => r.CarId);

            builder.Entity<Car>()
                .HasMany(c => c.Debts)
                .WithOne(d => d.Car)
                .HasForeignKey(d => d.CarId);

            base.OnModelCreating(builder);
        }
    }
}
