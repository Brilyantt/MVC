using CarMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMVC.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString = @"Server=BRILYANT\SQLEXPRESS;Database=CarDb;Trusted_Connection=True;TrustServerCertificate=True";

        public DbSet<FeaturedCar> FeaturedCars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
