using Evently.Common.Domain.Events;

namespace Evently.Modules.Ticketing.Domain.Tickets.DomainEvents;

public sealed class TicketCreatedDomainEvent(Guid ticketId) : DomainEvent
{
    public Guid TicketId { get; init; } = ticketId;
}