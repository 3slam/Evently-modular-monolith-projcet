namespace Evently.Modules.Events.Infrastructure.Events;

internal sealed class EventRepository(EventsDbContext db) : IEventRepository
{
    public async Task AddAsync(Event @event, CancellationToken cancellationToken = default)
    {
       await db.Events.AddAsync(@event);
    }

    public async Task<Event?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await db.Events.SingleOrDefaultAsync(@event => @event.Id == id, cancellationToken);
    }
}