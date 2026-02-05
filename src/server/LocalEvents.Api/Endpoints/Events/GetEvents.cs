using LocalEvents.Api.Endpoints._internal;

namespace LocalEvents.Api.Endpoints.Events;

public class GetEvents : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/events", () =>
            Results.Ok(EventStore.Events)
        );
    }
}