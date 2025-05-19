
using Microsoft.EntityFrameworkCore;
using Villa_MVC_Project.DAL.Models;

namespace Villa_MVC_Project.DAL.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Villa> Villas { get; set; }
}
