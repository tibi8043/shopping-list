using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;

namespace ShoppingList.Data {
    public class MyDbContext : DbContext {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {

        }

        public DbSet<Item> Items { get; set; }
    }
}
