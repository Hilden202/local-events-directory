using LocalEvents.Api.Data;
using LocalEvents.Api.Endpoints._internal;
using LocalEvents.Api.Endpoints.Categories.Models;

namespace LocalEvents.Api.Endpoints.Categories;

public class PostCategory : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/categories", (string name, AppDbContext db) =>
        {
            if (string.IsNullOrWhiteSpace(name))
                return Results.BadRequest("Category name is required.");

            if (db.Categories.Any(c => c.Name == name))
                return Results.Conflict("Category already exists.");

            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            db.Categories.Add(category);
            db.SaveChanges();
            
            return Results.Created($"/categories/{category.Id}", category);
        });
    }
}