/// Hints
/// add-migration name -outputdir \DAL\DAO\EF\Migrations

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ServiceParser.Entities;
using System.IO;

namespace DAL.DAO.EF
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Snippet> Snippets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        #region Migrations
        /// <summary>
        /// For Migrations
        /// </summary>
        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {

            public ApplicationDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("DAL"));

                return new ApplicationDbContext(builder.Options);
            }
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.IdentityBuild();
        }
    }

    internal static class ModelCreatorExtensions
    {
        internal static void IdentityBuild(this ModelBuilder builder)
        {
            builder.Entity<Snippet>().Property(s => s.Title).IsRequired();
            builder.Entity<Snippet>().Property(s => s.Url).IsRequired();
        }
    }
}
