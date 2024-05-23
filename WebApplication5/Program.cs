using Microsoft.EntityFrameworkCore;
using WebApplication5.DAL;

namespace WebApplication5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt=>

            {
                opt.UseSqlServer("Server=CA-R215-PC11\\SQLEXPRESS; Database=Ab105_FirstWeb;Trusted_connection=true;Integrated security=true; Encrypt=false");
            });
            var app = builder.Build();


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}