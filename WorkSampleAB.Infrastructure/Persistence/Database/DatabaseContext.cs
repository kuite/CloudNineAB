using System;
using Microsoft.EntityFrameworkCore;
using WorkSampleAB.Domain;
using WorkSampleAB.Domain.Membership;
using WorkSampleAB.Domain.Music;

namespace WorkSampleAB.Infrastructure.Persistence.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<UserPreferences> UserPreferences => Set<UserPreferences>();

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            //var carCompact = new Car
            //{
            //    Id = Guid.NewGuid(),
            //    Type = CarType.Compact,
            //    Status = CarStatus.Available
            //};
            //var carMinivan = new Car
            //{
            //    Id = Guid.NewGuid(),
            //    Type = CarType.Minivan,
            //    Status = CarStatus.Available
            //};
            //var carPremium = new Car
            //{
            //    Id = Guid.NewGuid(),
            //    Type = CarType.Premium,
            //    Status = CarStatus.Available
            //};

            //modelBuilder.Entity<Car>().HasData(carCompact);
            //modelBuilder.Entity<Car>().HasData(carMinivan);
            //modelBuilder.Entity<Car>().HasData(carPremium);

            var password = "test";
            var user = new User
            {
                Id = 1,
                Email = "test@wp.pl",
                FirstName = "jan",
                LastName = "kowalski",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<UserPreferences>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
