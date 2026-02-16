using Evently.Common.Application.Abstraction.Data;
using Evently.Common.Infrastructure.Interceptors;
using Evently.Modules.Ticketing.Presentation;
using Evently.Common.Presentation.Endpoints;
namespace Evently.Modules.Ticketing.Infrastructure;

public static class TicketingModuleServiceRegister
{
    public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.RegisterAllClassesThatImplementIEndpoint(TicketingPresentationAssemblyReference.Assembly);
        return services;
    }
 
    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;

        services.AddDbContext<TicketingDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Ticketing"))
                .AddInterceptors(sp.GetRequiredService<CollectAndPublishDomainEventsInterceptor>()));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TicketingDbContext>());
        services.AddScoped<ITicketRepository, TicketRepository>();
    }
}