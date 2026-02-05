using LocalEvents.Api.Endpoints._internal;

namespace LocalEvents.Api.Endpoints.Categories;

public class PutCategory : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/categories", (string oldName, string newName) =>
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
                return Results.BadRequest("Both oldName and newName are required.");

            if (!CategoryStore.Categories.Contains(oldName))
                return Results.NotFound("Category not found.");

            if (CategoryStore.Categories.Contains(newName))
                return Results.BadRequest("Category with new name already exists.");

            CategoryStore.Categories.Remove(oldName);
            CategoryStore.Categories.Add(newName);

            return Results.NoContent();
        });
    }
}