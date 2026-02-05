using LocalEvents.Api.Endpoints._internal;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapEndpoints();

app.Run();
