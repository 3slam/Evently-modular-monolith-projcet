using Evently.Common.Domain.Events;

public sealed class TicketTypePriceChangedDomainEvent: DomainEvent
{
    public required Guid TicketTypeId { get; init; }
    public required decimal Price { get; init; } 
}
