using Microsoft.EntityFrameworkCore;

public class CoffeeDbContext: DbContext
{
    public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; } = default!;
    public DbSet<MenuItem> MenuItems { get; set; } = default!;
    public DbSet<Customer> Customers { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed MenuItem data
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { Id = 1, Name = "Espresso", Category = "Coffee", Price = 120, Available = true },
            new MenuItem { Id = 2, Name = "Cappuccino", Category = "Coffee", Price = 150, Available = true },
            new MenuItem { Id = 3, Name = "Latte", Category = "Coffee", Price = 160, Available = true },
            new MenuItem { Id = 4, Name = "Blueberry Muffin", Category = "Snack", Price = 80, Available = true }
        );

        // Seed Customers
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Name = "Vishnu", Email = "vishnu@example.com", LoyaltyPoints = 50 },
            new Customer { Id = 2, Name = "Anita", Email = "anita@example.com", LoyaltyPoints = 20 }
        );

        // Configure relationships
        modelBuilder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey("OrderId")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>()
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure column types
        modelBuilder.Entity<MenuItem>()
            .Property(m => m.Price)
            .HasColumnType("decimal(10,2)");
    }
}