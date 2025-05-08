using Fiorella.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorella.Contexts;

public class AppDbContext : DbContext
{
    private readonly string _connectionString = @"Server=BRILYANT\SQLEXPRESS;Database=FiorellaDb;Trusted_Connection=True;TrustServerCertificate=True";

    public DbSet<Flower> Flowers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}
