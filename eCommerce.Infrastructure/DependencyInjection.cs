using System;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
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
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
}
