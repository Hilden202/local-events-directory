namespace LocalEvents.Api.Endpoints._internal;

public static class EndpointExtensions
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        // 1. Hämta assemblyn där IEndpoint (och alla endpoints) är definierade
        var assembly = typeof(IEndpoint).Assembly;

        // 2. Hitta alla konkreta typer som implementerar IEndpoint
        var endpointTypes = assembly.DefinedTypes
            .Where(x => !x.IsAbstract
                        && !x.IsInterface
                        && typeof(IEndpoint).IsAssignableFrom(x));
        
        // 3. Anropa MapEndpoint för varje endpoint-typ
        foreach (var endpointType in endpointTypes)
        {
            endpointType.GetMethod(nameof(IEndpoint.MapEndpoint))!
                .Invoke(null, new object[] { app });
        }
    }
}