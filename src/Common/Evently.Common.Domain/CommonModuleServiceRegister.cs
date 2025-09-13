
using Evently.Common.Domain.Clock;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace Evently.Modules.Events.Infrastructure;

public static class CommonModuleServiceRegister
{
    public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
    {

        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }     
}
