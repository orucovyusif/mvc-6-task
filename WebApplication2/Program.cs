using Microsoft.EntityFrameworkCore;
using WebApplication2.DAL;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer("Server=CA-R215-PC11\\SQLEXPRESS;Database=Ab105_FirstWeb;Trusted_connection=true;Integrated security=true;Encrypt=false");
            });
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}"
                );
            

            app.Run();
        }
    }
}