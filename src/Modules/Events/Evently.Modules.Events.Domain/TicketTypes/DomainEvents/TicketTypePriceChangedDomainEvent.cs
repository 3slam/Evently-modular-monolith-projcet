using Evently.Common.Domain.Events;

namespace Evently.Modules.Events.Domain.TicketTypes.DomainEvents;

public sealed class TicketTypePriceChangedDomainEvent : DomainEvent
{
    public required Guid TicketTypeId { get; init; }
    public required decimal Price { get; init; }
}