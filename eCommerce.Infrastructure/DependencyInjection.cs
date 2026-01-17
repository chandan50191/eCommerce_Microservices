using System;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;
/// <summary>
/// Extension method to add core services to the dependency injection container
/// </summary>

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Note: The this keyword tells C#: that “This method extends IServiceCollection”
        // TODO: Add Services to IoC container
        // Infrastructure services often include data access, caching and other low-level components

        return services;
    }
}
