using Fiorella.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorella.Contexts;

public class AppDbContext : DbContext
{
    private readonly string _connectionString = @"Server=CODE_PC_7_213_1\SQLEXPRESS;Database=FiorellaDb;Trusted_Connection=True;TrustServerCertificate=True";

    public DbSet<Flower> Flower { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}
