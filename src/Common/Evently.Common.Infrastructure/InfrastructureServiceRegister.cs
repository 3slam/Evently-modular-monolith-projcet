using Evently.Common.Application.Cache;
using Evently.Common.Infrastructure.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Evently.Common.Infrastructure;

public static class InfrastructureServiceRegister
{
    public static IServiceCollection Register(IServiceCollection services ,IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options => options.Configuration = configuration.GetConnectionString("Cache"));
        services.TryAddSingleton<ICacheService, CacheService>();
        return services;
    }
}
