using BookLibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
