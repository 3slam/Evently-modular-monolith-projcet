using Evently.Modules.Ticketing.Domain.Tickets.Models;

namespace Evently.Modules.Ticketing.Domain.Tickets.Repository;

public interface ITicketRepository
{
    Task<Ticket?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Ticket?> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Ticket>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Ticket>> GetByEventIdAsync(Guid eventId, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Ticket>> GetAllAsync(CancellationToken cancellationToken = default);
    void Insert(Ticket ticket);
    void InsertRange(IEnumerable<Ticket> tickets);
}

 