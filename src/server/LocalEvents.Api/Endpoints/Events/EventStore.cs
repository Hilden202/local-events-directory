using LocalEvents.Api.Endpoints.Events.Models;

namespace LocalEvents.Api.Endpoints.Events;

public static class EventStore
{
    public static readonly List<Event> Events = new()
    {
        new Event
        {
            Id = Guid.NewGuid(),
            Title = "Rockfest i hamnen",
            CategoryName = "Music"
        },
        new Event
        {
            Id = Guid.NewGuid(),
            Title = "AI Meetup Nyköping",
            CategoryName = "Tech"
        }
    };
}

