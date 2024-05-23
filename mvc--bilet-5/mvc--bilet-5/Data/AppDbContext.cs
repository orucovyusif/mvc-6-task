using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc__bilet_5.Models;

namespace mvc__bilet_5.Data
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Designs> Designs { get; set; }
	}
}
