
using Microsoft.EntityFrameworkCore;
using NFT_MVCProject.DAL.Models;

namespace NFT_MVCProject.DAL.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<CollectionsMarket> CollectionsMarkets { get; set; }


}
