using Evently.Modules.Ticketing.Domain.TicketsType;

namespace Evently.Modules.Ticketing.Infrastructure.Repository;

internal class TicketTypeRepository : ITicketTypeRepository
{
    public Task<TicketType?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TicketType?> GetWithLockAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void InsertRange(IEnumerable<TicketType> ticketTypes)
    {
        throw new NotImplementedException();
    }
}