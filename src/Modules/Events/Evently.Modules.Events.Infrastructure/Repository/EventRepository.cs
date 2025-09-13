namespace Evently.Modules.Events.Infrastructure.Events;

internal sealed class EventRepository(EventsDbContext db) : IEventRepository
{
    public async Task AddAsync(Event @event, CancellationToken cancellationToken = default)
    {
       await db.Events.AddAsync(@event, cancellationToken);
    }

    public async Task<Event?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await db.Events.SingleOrDefaultAsync(@event => @event.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Event>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await db.Events.ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Event>> SearchAsync(string? title, DateTime? startsAtUtc, CancellationToken cancellationToken = default)
    {
        var query = db.Events.AsQueryable();
        if (!string.IsNullOrWhiteSpace(title))
            query = query.Where(e => e.Title.Contains(title));
        if (startsAtUtc.HasValue)
            query = query.Where(e => e.StartsAtUtc.Date == startsAtUtc.Value.Date);
        return await query.ToListAsync(cancellationToken);
    }
}