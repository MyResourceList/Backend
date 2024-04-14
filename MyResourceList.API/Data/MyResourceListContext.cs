using Microsoft.EntityFrameworkCore;
using MyResourceList.API.Models;

namespace MyResourceList.API.Data
{
    public class MyResourceListContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MyResourceListContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceTag>()
                .HasKey(rt => new { rt.ResourceId, rt.TagId });
        }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ResourceTag> ResourceTags { get; set; }
    }
}
