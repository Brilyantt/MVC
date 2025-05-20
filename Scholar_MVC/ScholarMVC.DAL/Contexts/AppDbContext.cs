
using Microsoft.EntityFrameworkCore;
using ScholarMVC.DAL.Models;

namespace ScholarMVC.DAL.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Cource> Cources { get; set; }
}
