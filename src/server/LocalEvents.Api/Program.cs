using LocalEvents.Api.Endpoints._internal;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(); // Skapar OpenAPI-dokumentet (metadata → JSON)

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapOpenApi(); // Exponerar OpenAPI-dokumentet som HTTP endpoint (/openapi/v1.json)
app.MapEndpoints();
app.MapScalarApiReference();

app.Run();
