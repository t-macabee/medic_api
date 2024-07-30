using Medic.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medic.API.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<User>()
           .HasOne(u => u.Role)
           .WithMany(r => r.Users)
           .HasForeignKey(u => u.RoleId);

            base.OnModelCreating(modelBuilder);

            SeedData.Seed(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
