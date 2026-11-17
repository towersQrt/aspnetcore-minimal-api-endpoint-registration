using Regnier.Web.Endpoints;
using Regnier.Web.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpoints(typeof(IEndpoint).Assembly);

WebApplication app = builder.Build();

app.MapEndpoints();

await app.RunAsync();
