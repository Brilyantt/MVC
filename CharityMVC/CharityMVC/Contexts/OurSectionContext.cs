using CharityMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CharityMVC.Contexts;

public class OurSectionContext : DbContext
{
    private readonly string _connectionString = @"Server=BRILYANT\SQLEXPRESS;Database=CharityDb;Trusted_Connection=True;TrustServerCertificate=True;";

    public DbSet<OurSection> OurSections { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}
