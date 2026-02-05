using LocalEvents.Api.Data;
using LocalEvents.Api.Endpoints._internal;

namespace LocalEvents.Api.Endpoints.Categories;

public class GetCategories : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/categories", (AppDbContext db) =>
            Results.Ok(db.Categories.ToList())
        );
    }
}