using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

          

        }

        public DbSet<SpongeBobFriends> spongeBobFriends { get; set; }
        public DbSet<Home> homes { get; set; }

    }
}
