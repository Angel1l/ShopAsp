using Microsoft.EntityFrameworkCore;
using Project.Data.Models;

namespace Project.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<Guns> Guns { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopGunsItem> ShopGunsItem { get; set; }

    }
}
