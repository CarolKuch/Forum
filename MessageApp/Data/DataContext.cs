using MessageApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Topic> Topics => Set<Topic>();
        public DbSet<Category> Categories => Set<Category>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Title).IsUnique();
        }
    }
}
