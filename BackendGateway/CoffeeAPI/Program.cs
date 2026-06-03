using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
// using BackendGateway.Infrastructure; // removed - assembly/namespace not found in this project

var builder = WebApplication.CreateBuilder(args);
var AllowspecficOrigins = "_allowspecficOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowspecficOrigins, policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});
// Register a DbContextFactory so services can create contexts on demand.
builder.Services.AddDbContextFactory<CoffeeDbContext>(options =>
    options.UseInMemoryDatabase("CoffeeDb"));

builder.Services.AddScoped<IMenuItemServices, MenuItemServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering();



var app = builder.Build();

app.UseCors(AllowspecficOrigins);
app.MapGraphQL();

app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions{
    GraphQLEndPoint = "/graphql"
});

app.Run();
