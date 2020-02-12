using Microsoft.EntityFrameworkCore;
using CV.Agents;
using CV.Map;

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
        public DbSet<Terrain> Terrain {get;set;}

    }
}
