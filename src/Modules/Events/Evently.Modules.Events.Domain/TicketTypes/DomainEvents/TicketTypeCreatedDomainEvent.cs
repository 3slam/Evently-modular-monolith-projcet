using Evently.Common.Domain.Events;

public sealed class TicketTypeCreatedDomainEvent : DomainEvent
{
    public required Guid TicketTypeId { get; init; } 
}
