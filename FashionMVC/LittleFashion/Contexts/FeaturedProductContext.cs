using LittleFashion.Models;
using Microsoft.EntityFrameworkCore;

namespace LittleFashion.Contexts;

public class FeaturedProductContext : DbContext
{
    private readonly string _connectionstring = @"Server=CODE_PC_7_213_1\SQLEXPRESS;Database=LittleFashionDb;Trusted_Connection=True;TrustServerCertificate=True;";

    public DbSet<FeaturedProduct> FeaturedProducts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionstring);
        base.OnConfiguring(optionsBuilder);
    }
}
