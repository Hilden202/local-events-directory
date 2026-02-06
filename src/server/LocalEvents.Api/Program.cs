using LocalEvents.Api.Endpoints._internal;
using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using LocalEvents.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(); // Skapar OpenAPI-dokumentet (metadata → JSON)

// EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Default")
    );
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.MapGet("/", () => Results.Redirect("/scaler"));
}
else
{
    app.MapGet("/", () => Results.Ok("OK"));
}

app.MapEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Exponerar OpenAPI-dokumentet som HTTP endpoint (/openapi/v1.json)
    app.MapScalarApiReference();
}

app.Run();
