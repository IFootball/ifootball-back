using IFootball.Domain.Models;
using IFootball.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace IFootball.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<TeamClass> TeamClasses { get; set; }
        public DbSet<Goalkeeper> Goalkeepers { get; set; }
        public DbSet<Coach> Coches { get; set; }
        public DbSet<LinePlayer> LinePlayers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=../IFootball.Infrastructure/database.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ClassMap());
            modelBuilder.ApplyConfiguration(new GenderMap());
            modelBuilder.ApplyConfiguration(new TeamUserMap());
            modelBuilder.ApplyConfiguration(new TeamClassMap());
            modelBuilder.ApplyConfiguration(new GoalkeeperMap());
            modelBuilder.ApplyConfiguration(new CoachMap());
            modelBuilder.ApplyConfiguration(new LinePlayerMap());
        }
    }
}
