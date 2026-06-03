using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class MenuItemServices: IMenuItemServices
{
    private readonly IDbContextFactory<CoffeeDbContext> _context;

    public MenuItemServices(IDbContextFactory<CoffeeDbContext> context)
    {
        _context = context;
    }

    public List<MenuItem> GetMenuItems()
    {
        using var ctx = _context.CreateDbContext();
        ctx.Database.EnsureCreated();
        return ctx.MenuItems.AsNoTracking().ToList();
    }
}