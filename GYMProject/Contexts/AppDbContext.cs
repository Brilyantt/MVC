using GYMProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GYMProject.Contexts;

public class AppDbContext : DbContext
{
    private readonly string _connectionString = @"Server=CODE_PC_7_213_1\SQLEXPRESS;Database=GymDb2;Trusted_Connection=True;TrustServerCertificate=True;";

    public DbSet<GymProgram> gymPrograms { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}
