using System.Reflection;
using Regnier.Web.Endpoints;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Regnier.Web.Extensions;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        ServiceDescriptor[] lstServiceDescriptor = assembly
            .DefinedTypes
            .Where(x => x is { IsAbstract: false, IsInterface: false } &&
                           x.IsAssignableTo(typeof(IEndpoint)))
            .Select(x => ServiceDescriptor.Transient(typeof(IEndpoint), x))
            .ToArray();

        services.TryAddEnumerable(lstServiceDescriptor);

        return services;
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        IEnumerable<IEndpoint> lstEndpoint = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();
        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;
        foreach (IEndpoint endpoint in lstEndpoint)
        {
            endpoint.MapEndpoint(builder);
        }
        return app;
    }
}