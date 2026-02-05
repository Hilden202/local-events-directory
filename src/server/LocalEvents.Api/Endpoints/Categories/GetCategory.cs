using LocalEvents.Api.Data;
using LocalEvents.Api.Endpoints._internal;

namespace LocalEvents.Api.Endpoints.Categories;

public class GetCategory : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/categories/{id}", (Guid id, AppDbContext db) =>
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            
            if (category is null)
                return Results.NotFound();

            return Results.Ok(category);
        });
    }
}