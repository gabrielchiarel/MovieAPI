using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using System;

namespace MovieAPI.Controllers.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Relationship 1:1
            builder.Entity<Address>()
                .HasOne(address => address.Theater)
                .WithOne(theater => theater.Address)
                .HasForeignKey<Theater>(theater => theater.AddressId);
            builder.Entity<Theater>()
                .HasOne(theater => theater.Manager)
                .WithMany(manager => manager.Theaters)
                .HasForeignKey(theater => theater.ManagerId).OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}
