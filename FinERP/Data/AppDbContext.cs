using Microsoft.EntityFrameworkCore;

namespace FinERP.Data
{
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }   
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<InventoryManagement> InventoryManagements { get; set; }
        public DbSet<User> Users { get; set; }
    }    
}

