namespace CharityMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Collection}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(

                name: "deafult",
                pattern: "{controller=Home}/{action=Index}"
                );
            app.Run();
        }
    }
}
