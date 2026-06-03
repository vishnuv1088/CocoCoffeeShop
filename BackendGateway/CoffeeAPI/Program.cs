using Microsoft.EntityFrameworkCore;
// using BackendGateway.Infrastructure; // removed - assembly/namespace not found in this project

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CoffeeDbContext>(options =>
    options.UseInMemoryDatabase("CoffeeDb"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering();

// Add services to the container.
// Learn more about onfiguring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGraphQL();

// Configure the HTTP request pipeline.
/* if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection(); */

/* var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
}; */

/* app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
 */
app.Run();

/* record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
} */
