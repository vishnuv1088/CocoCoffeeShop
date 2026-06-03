public class Query
{
    public IQueryable<MenuItem> GetMenuItems([Service] CoffeeDbContext db)
    {
        db.Database.EnsureCreated();
        return db.MenuItems;
    }
   
    public IQueryable<Order> GetOrders([Service] CoffeeDbContext db, int customerId) =>
        db.Orders.Where(o => o.CustomerId == customerId);
    public Customer GetCustomer([Service] CoffeeDbContext db, int id) =>
        db.Customers.FirstOrDefault(c => c.Id == id)!;
}