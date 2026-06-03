public class Query
{
    public System.Collections.Generic.List<MenuItem> GetMenuItems([Service] IMenuItemServices menuItemServices)
    {
        return menuItemServices.GetMenuItems();
    }

   
    public System.Collections.Generic.List<Order> GetOrders([Service] Microsoft.EntityFrameworkCore.IDbContextFactory<CoffeeDbContext> dbFactory, int customerId)
    {
        using var db = dbFactory.CreateDbContext();
        db.Database.EnsureCreated();
        return db.Orders.Where(o => o.CustomerId == customerId).ToList();
    }

    public Customer GetCustomer([Service] ICustomerServices customerServices, int id)
    {
        return customerServices.GetCustomers().FirstOrDefault(c => c.Id == id)!;
    }
}