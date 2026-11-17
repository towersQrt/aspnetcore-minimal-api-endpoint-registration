namespace Regnier.Web.Endpoints;

internal sealed class Hello : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => Results.Ok("Hello World"));
    }
}
