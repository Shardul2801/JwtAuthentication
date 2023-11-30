using JwtBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtBackend.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("users");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        if(!optionsBuilder.IsConfigured){
            optionsBuilder.UseSqlServer("User ID=sa;password=examlyMssql@123; server=localhost;Database=AuthDb;trusted_connection=false;Persist Security Info=False;Encrypt=False;");
        }
        }
    }
}