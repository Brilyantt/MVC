using CarMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMVC.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString = @"Server=CODE_PC_7_213_1\SQLEXPRESS;Database=CarDb;Trusted_Connection=True;TrustServerCertificate=True";

        public DbSet<FeaturedCar> featuredCars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
