using LocalEvents.Api.Endpoints._internal;
using LocalEvents.Api.Endpoints.Events.Models;

namespace LocalEvents.Api.Endpoints.Events;

public class PutEvent : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/events/{id}", (Guid id, UpdateEventRequest request) =>
        {
            // 1. Hitta befintligt event
            var existingEvent = EventStore.Events
                .FirstOrDefault(e => e.Id == id);

            // 2. Finns det inte → 404
            if (existingEvent is null)
                return Results.NotFound();

            // 3. Uppdatera fält
            existingEvent.Title = request.Title;
            existingEvent.CategoryName = request.CategoryName;

            // 4. PUT returnerar inget innehåll
            return Results.NoContent();
        });
    }
}