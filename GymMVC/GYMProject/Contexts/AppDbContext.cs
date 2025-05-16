using GYMProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GYMProject.Contexts;

public class AppDbContext : DbContext
{
    private readonly string _connectionString = @"Server=BRILYANT\SQLEXPRESS;Database=GymDb2;Trusted_Connection=True;TrustServerCertificate=True;";

    public DbSet<GymProgram> gymPrograms { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}
