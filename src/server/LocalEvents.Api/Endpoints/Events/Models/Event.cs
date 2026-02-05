namespace LocalEvents.Api.Endpoints.Events.Models;

public class Event
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string CategoryName { get; set; }
}