using AgentUtitilies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseService.DbClass
{
    public class VillageContext : DbContext
    {
        //public VillageContext(DbContextOptions opts) : base(opts)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rabbit>().ToTable("Rabbits");
            modelBuilder.Entity<Tree>().ToTable("Trees");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Village;Integrated Security=True");
        }


        public DbSet<Rabbit> Agents { get; set; }
        public DbSet<Tree> Trees { get; set; }
    }
}
