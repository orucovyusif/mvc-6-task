using Microsoft.EntityFrameworkCore;

namespace WebApplication5.DAL {
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Slider> Sliders { get; set; }
    }
}
