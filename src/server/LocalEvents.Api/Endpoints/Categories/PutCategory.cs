using LocalEvents.Api.Endpoints._internal;

namespace LocalEvents.Api.Endpoints.Categories;

public class PutCategory : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/categories/{name}", (string name, string newName) =>
        {
            if (string.IsNullOrWhiteSpace(newName))
                return Results.BadRequest("newName is required.");

            if (!CategoryStore.Categories.Contains(name))
                return Results.NotFound();

            if (CategoryStore.Categories.Contains(newName))
                return Results.BadRequest("Category already exists.");

            CategoryStore.Categories.Remove(name);
            CategoryStore.Categories.Add(newName);

            return Results.NoContent();
        });
    }
}