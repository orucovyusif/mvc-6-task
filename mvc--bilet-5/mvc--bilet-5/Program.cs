using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvc__bilet_5.Data;
using mvc__bilet_5.Models;

namespace mvc__bilet_5
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

			builder.Services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
			});



			var app = builder.Build();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();


			app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=Designs}/{action=Index}/{id?}"
          );
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}