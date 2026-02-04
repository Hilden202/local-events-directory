namespace LocalEvents.Api.Endpoints._internal;

// Kontrakt för registrering av endpoints vid uppstart
public interface IEndpoint
{
    public static abstract void MapEndpoint(IEndpointRouteBuilder app);
    
}