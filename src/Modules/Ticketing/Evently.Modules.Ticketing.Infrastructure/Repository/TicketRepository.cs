namespace Evently.Modules.Ticketing.Infrastructure.Repository;

internal sealed class TicketRepository(TicketingDbContext db) : ITicketRepository
{
    public async Task<Ticket?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await db.Tickets.SingleOrDefaultAsync(ticket => ticket.Id == id, cancellationToken);
    }

    public async Task<Ticket?> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        return await db.Tickets.SingleOrDefaultAsync(ticket => ticket.Code == code, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Ticket>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        return await db.Tickets
            .Where(ticket => ticket.CustomerId == customerId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Ticket>> GetByEventIdAsync(Guid eventId, CancellationToken cancellationToken = default)
    {
        return await db.Tickets
            .Where(ticket => ticket.EventId == eventId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Ticket>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await db.Tickets.ToListAsync(cancellationToken);
    }

    public void Insert(Ticket ticket)
    {
        db.Tickets.Add(ticket);
    }

    public void InsertRange(IEnumerable<Ticket> tickets)
    {
        db.Tickets.AddRange(tickets);
    }
}