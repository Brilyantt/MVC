using Microsoft.EntityFrameworkCore;
using Villa_MVC_Project.BL.Services;
using Villa_MVC_Project.DAL.Contexts;

namespace Villa_MVC_Project.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            string connectionStr = builder.Configuration.GetConnectionString("Desktop");
            builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(connectionStr)

            );

            builder.Services.AddScoped<VillaService>();

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
}
