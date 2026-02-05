using LocalEvents.Api.Endpoints._internal;

namespace LocalEvents.Api.Endpoints.Categories;

public class DeleteCategory : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/categories", (string name) =>
        {
            if (string.IsNullOrWhiteSpace(name))
                return Results.BadRequest("Category name is required.");

            if (!CategoryStore.Categories.Contains(name))
                return Results.NotFound();

            CategoryStore.Categories.Remove(name);
            return Results.NoContent();
        });
    }
}