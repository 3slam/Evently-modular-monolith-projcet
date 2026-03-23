using Evently.Common.Application.Abstraction.Data;
using Evently.Common.Infrastructure.Interceptors;
using Evently.Modules.Users.Domain.Repository;
using Evently.Modules.Users.Infrastructure.Data;
using Evently.Modules.Users.Infrastructure.Repository;
using Evently.Modules.Users.Presentation;
using Evently.Common.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Users.Infrastructure;

public static class UsersModuleServiceRegister
{
    public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.RegisterAllClassesThatImplementIEndpoint(UsersPresentationAssemblyReference.Assembly);
        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;

        services.AddDbContext<UserDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, "users"))
                .AddInterceptors(sp.GetRequiredService<CollectAndPublishDomainEventsInterceptor>()));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<UserDbContext>());
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
