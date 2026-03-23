using Evently.Modules.Events.Infrastructure.Database;
using Evently.Modules.Users.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Evently.API.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        Migrate<EventsDbContext>(scope);
        Migrate<UserDbContext>(scope);
    }

    private static void Migrate<T>(IServiceScope scope) where T : DbContext
    {
        try
        {
            using var dbContext = scope.ServiceProvider.GetRequiredService<T>();
            dbContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while applying migrations for {typeof(T).Name}: {ex.Message}");
        }
    }
}