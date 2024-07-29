using Domain.Entities;
using Domain.Enum;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Name = "BMW",
                    Type = BrandType.Car
                },
                new Brand
                {
                    Name = "AUDI",
                    Type = BrandType.Car
                },
                new Brand
                {
                    Name = "TOYOTA",
                    Type = BrandType.Car
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
