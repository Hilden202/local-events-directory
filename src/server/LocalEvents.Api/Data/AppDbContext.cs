using Microsoft.EntityFrameworkCore;
using LocalEvents.Api.Endpoints.Categories;
using LocalEvents.Api.Endpoints.Categories.Models;
using LocalEvents.Api.Endpoints.Events.Models;

namespace LocalEvents.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Event> Events => Set<Event>();
}