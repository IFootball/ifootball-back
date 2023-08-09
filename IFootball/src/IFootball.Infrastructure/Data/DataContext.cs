using IFootball.Domain.Models;
using IFootball.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlite(connectionString);
            }
        }

        //=> options.UseSqlite("DataSource=../IFootball.Infrastructure/database.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ClassMap());
            modelBuilder.ApplyConfiguration(new GenderMap());
            modelBuilder.ApplyConfiguration(new TeamUserMap());
            modelBuilder.ApplyConfiguration(new TeamClassMap());
            modelBuilder.ApplyConfiguration(new GoalkeeperMap());
            modelBuilder.ApplyConfiguration(new PlayerMap());
        }
    }
}
