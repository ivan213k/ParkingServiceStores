using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingServiceStores.Data.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

            var utcNow = DateTime.UtcNow;
            foreach (var entry in entries)
            {
                (entry.Entity as BaseEntity).UpdatedOn = utcNow;
                if (entry.State == EntityState.Added)
                {
                    (entry.Entity as BaseEntity).CreatedOn = utcNow;
                }
            }
        }
    }
}
