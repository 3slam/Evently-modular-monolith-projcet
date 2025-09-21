using Evently.Common.Application.Behaviors;
using Evently.Common.Application.Clock;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Evently.Common.Application;

public static class ApplicationServiceRegister
{
    public static IServiceCollection Register(
        IServiceCollection services ,
        Assembly[] assemblies)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(assemblies);
            configuration.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            configuration.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
        });
        services.AddValidatorsFromAssemblies(assemblies);
        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services; 
    }
}
