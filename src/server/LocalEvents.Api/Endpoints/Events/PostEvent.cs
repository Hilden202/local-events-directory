using LocalEvents.Api.Endpoints._internal;
using LocalEvents.Api.Endpoints.Categories;
using LocalEvents.Api.Endpoints.Events.Models;

namespace LocalEvents.Api.Endpoints.Events;

public class PostEvent : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/events", (CreateEventRequest request) =>
        {
            // 1. Enkel validering
            if (string.IsNullOrWhiteSpace(request.Title))
                return Results.BadRequest("Event Title is required.");

            // 2. Skapa nytt Event (servern äger Id)
            var newEvent = new Event
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                CategoryName = request.CategoryName
            };
            
            // 3. Lägg till i EventStore
            EventStore.Events.Add(newEvent);
            
            // 4. Returnera korrekt REST-svar
            return Results.Created($"/events/{newEvent.Id}", newEvent);
        });
    }
}