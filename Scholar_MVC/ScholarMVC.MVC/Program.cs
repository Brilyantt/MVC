using Microsoft.EntityFrameworkCore;
using ScholarMVC.BL.Services;
using ScholarMVC.DAL.Contexts;

namespace ScholarMVC.MVC
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


            builder.Services.AddScoped<CourceService>();
            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}"
                );

            app.Run();
        }
    }
}
