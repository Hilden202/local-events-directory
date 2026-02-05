using LocalEvents.Api.Data;
using LocalEvents.Api.Endpoints._internal;
using LocalEvents.Api.Endpoints.Categories.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalEvents.Api.Endpoints.Categories;

public class PutCategory : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/categories/{id}", (Guid id, string newName, AppDbContext db) =>
        {
            if (string.IsNullOrWhiteSpace(newName))
                return Results.BadRequest("newName is required.");

            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null)
                return Results.NotFound();

            if (db.Categories.Any(c => c.Name == newName && c.Id != id))
                return Results.BadRequest("Category already exists.");
            
            category.Name = newName;
            
            db.SaveChanges();

            return Results.NoContent();
        });
    }
}