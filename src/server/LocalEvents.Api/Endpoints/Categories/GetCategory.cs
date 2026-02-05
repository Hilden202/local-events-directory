using LocalEvents.Api.Endpoints._internal;

namespace LocalEvents.Api.Endpoints.Categories;

public class GetCategory : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/categories/{name}", (string name) =>
        {
            if (!CategoryStore.Categories.Contains(name))
                return Results.NotFound();

            return Results.Ok(name);
        });
    }
}