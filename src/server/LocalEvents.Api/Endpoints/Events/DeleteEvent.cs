using LocalEvents.Api.Data;
using LocalEvents.Api.Endpoints._internal;
using LocalEvents.Api.Endpoints.Events.Models;

namespace LocalEvents.Api.Endpoints.Events;

public class DeleteEvent : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/events/{id}", (Guid id, AppDbContext db) =>
        {
            // 1. Hitta eventet
            var existingEvent = db.Events
                .FirstOrDefault(e => e.Id == id);

            // 2. Finns det inte → 404
            if (existingEvent is null)
                return Results.NotFound();

            // 3. Ta bort
            db.Events.Remove(existingEvent);
            db.SaveChanges();

            // 4. DELETE returnerar inget innehåll
            return Results.NoContent();
        });
    }
}