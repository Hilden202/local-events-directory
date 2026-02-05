using LocalEvents.Api.Data;
using LocalEvents.Api.Endpoints._internal;


namespace LocalEvents.Api.Endpoints.Categories;

public class DeleteCategory : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/categories/{id}", (Guid id, AppDbContext db) =>
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);

            if (category is null)
                return Results.NotFound();

            db.Categories.Remove(category);
            db.SaveChanges();

            return Results.NoContent();
        });
    }
}