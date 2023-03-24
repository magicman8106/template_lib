using Microsoft.EntityFrameworkCore;
using my_library.Models;

namespace my_library.Data
{
    
    public class AppDbContext : DbContext
    {
        public DbSet<Media> media { get; set; }
        public DbSet<book> books { get; set; }
        public DbSet<computer> computers { get; set; }
        public AppDbContext()
        {

        }
        
        protected readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseNpgsql(Configuration.GetConnectionString("Default"));
        }
        

        

    }
}
