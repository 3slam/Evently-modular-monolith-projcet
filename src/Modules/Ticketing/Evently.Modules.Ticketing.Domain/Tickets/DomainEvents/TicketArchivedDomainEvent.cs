using Evently.Common.Domain;
using Evently.Common.Domain.Events;

namespace Evently.Modules.Ticketing.Domain.Tickets.DomainEvents;

public sealed class TicketArchivedDomainEvent(Guid ticketId, string code) : DomainEvent
{
    public Guid TicketId { get; init; } = ticketId;
    public string Code { get; init; } = code;
}