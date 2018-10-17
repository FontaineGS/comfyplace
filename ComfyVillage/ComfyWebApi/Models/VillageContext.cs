using Microsoft.EntityFrameworkCore;
using AgentUtitilies;

namespace ComfyWebApi.Models
{
    public class VillageContext : DbContext
    {
        public VillageContext(DbContextOptions<VillageContext> options)
            : base(options)
        {
        }

        public DbSet<Rabbit> Rabbits { get; set; }
        public DbSet<Tree> Trees { get; set; }
    }
}
