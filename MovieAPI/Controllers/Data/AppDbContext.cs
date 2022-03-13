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

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Adress> Adresses { get; set; }
    }
}
