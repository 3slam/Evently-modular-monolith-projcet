using Evently.Modules.Events.Domain.TicketTypes.Models;

namespace Evently.Modules.Events.Domain.TicketTypes.Repository;

public interface ITicketTypeRepository
{
    Task<TicketType?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<TicketType>> GetByEventIdAsync(Guid eventId, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid eventId, CancellationToken cancellationToken = default);
    void Insert(TicketType ticketType);
}