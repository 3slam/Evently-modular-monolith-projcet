using Evently.Common.Application.Abstraction.Data;
namespace Evently.Modules.Events.Infrastructure.Database;

public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Event> Events { get; set; }

    internal DbSet<Category> Categories { get; set; }

    internal DbSet<TicketType> TicketTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>().HasOne<Category>().WithMany();
        modelBuilder.Entity<TicketType>()
            .HasOne<Event>()
            .WithMany()
            .HasForeignKey(ticketType => ticketType.EventId);
    }
}
