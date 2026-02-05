using LocalEvents.Api.Endpoints._internal;

namespace LocalEvents.Api.Endpoints.Categories;

public class PostCategory : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/catergories", (string name) =>
        {
            if (string.IsNullOrWhiteSpace(name))
                return Results.BadRequest("Category name is required.");

            if (CategoryStore.Catergories.Contains(name))
                return Results.Conflict("Category already exists.");

            CategoryStore.Catergories.Add(name);

            return Results.Created($"/categories/{name}", name);
        });
    }
}