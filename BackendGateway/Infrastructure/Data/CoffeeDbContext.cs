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

        // Seed Customer data
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Name = "John Doe", Email = "john@example.com", LoyaltyPoints= 300 },
            new Customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com", LoyaltyPoints= 150 }
        );

        // Seed MenuItem data
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { Id = 1, Name = "Espresso", Category = "Beverages", Price = 2.50m, Available= true },
            new MenuItem { Id = 2, Name = "Latte", Category = "Beverages", Price = 4.50m, Available= true },
            new MenuItem { Id = 3, Name = "Cappuccino", Category = "Beverages", Price = 4.50m, Available= true }
        );

        // Seed Order data
        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, CustomerId = 1, Status = "Pending" },
            new Order { Id = 2, CustomerId = 2, Status = "Completed" }
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