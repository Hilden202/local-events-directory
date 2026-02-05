using LocalEvents.Api.Endpoints._internal;

namespace LocalEvents.Api.Endpoints.Events;

public class GetEvent : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/events/{id}", (Guid id) =>
        {
            // 1. Försök hitta eventet i listan
            var foundEvent = EventStore.Events
                .FirstOrDefault(e => e.Id == id);
            
            // 2. Om inget hittades → 404
            if (foundEvent is null)
                return Results.NotFound();
            
            // 3. Annars → returnera eventet
            return Results.Ok(foundEvent);
        });
    }
}