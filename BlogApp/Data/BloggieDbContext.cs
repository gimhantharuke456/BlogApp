using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data
{
    public class BloggieDbContext : DbContext
    {
        public BloggieDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Catogories { get; set; }
    }
}