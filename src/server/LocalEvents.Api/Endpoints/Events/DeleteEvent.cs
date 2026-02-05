using LocalEvents.Api.Endpoints._internal;
using LocalEvents.Api.Endpoints.Events.Models;

namespace LocalEvents.Api.Endpoints.Events;

public class DeleteEvent : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/events/{id}", (Guid id) =>
        {
            // 1. Hitta eventet
            var existingEvent = EventStore.Events
                .FirstOrDefault(e => e.Id == id);

            // 2. Finns det inte → 404
            if (existingEvent is null)
                return Results.NotFound();

            // 3. Ta bort
            EventStore.Events.Remove(existingEvent);

            // 4. DELETE returnerar inget innehåll
            return Results.NoContent();
        });
    }
}