using Microsoft.EntityFrameworkCore;
using NFT_MVCProject.DAL.Contexts;

namespace NFT_MVCProject.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();


        builder.Services.AddScoped<AppDbContext>();

        string connectionSTR = builder.Configuration.GetConnectionString("Desktop");

        builder.Services.AddDbContext<AppDbContext>(
            opt => opt.UseSqlServer(connectionSTR)
            );

        var app = builder.Build();
        app.UseStaticFiles();

        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}"
            );

        app.Run();
    }
}
