using DemoApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        //basic configuration of EFCore
        // option for db context is connecting it with sql server
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        // Stadium Table regarding Stadium model 
        public DbSet<Stadium> Stadium { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Team> Team { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            //ignore gmaes inside Stadium Class
            modelBuilder.Entity<Stadium>().Ignore(t => t.Games);

            //one to many relation
            modelBuilder.Entity<Game>()
                .HasOne(c => c.Stadium).WithMany(e => e.Games).HasForeignKey(c => c.StadiumId);
        }

    }
}
