using System;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;
/// <summary>
/// Extension method to add core services to the dependency injection container
/// </summary>

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // Note: The this keyword tells C#: that “This method extends IServiceCollection”
        // TODO: Add Services to IoC container
        // Core services often include data access, caching and other low-level components
        services.AddTransient<IUsersService, UsersService>();
        return services;
    }
}
