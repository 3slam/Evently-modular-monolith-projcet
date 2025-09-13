using Evently.Modules.Events.Application;
using Evently.Modules.Events.Application.Abstraction.Data;
using FluentValidation;


namespace Evently.Modules.Events.Infrastructure;

public static class EventsModuleServiceRegister
{
    public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(ApplicationAssemblyReference.Assembly));
        services.AddValidatorsFromAssembly(ApplicationAssemblyReference.Assembly);
      

        return services;
    }
 
    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;

        services.AddDbContext<EventsDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Events")));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDbContext>());

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}
