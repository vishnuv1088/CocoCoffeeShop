using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class CustomerServices: ICustomerServices
{
    private readonly IDbContextFactory<CoffeeDbContext> _context;

    public CustomerServices(IDbContextFactory<CoffeeDbContext> context)
    {
        _context = context;
    }

    public List<Customer> GetCustomers()
    {
        using var ctx = _context.CreateDbContext();
        ctx.Database.EnsureCreated();
        return ctx.Customers.AsNoTracking().ToList();
    }
}