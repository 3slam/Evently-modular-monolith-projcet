using Evently.Common.Domain.Events;

namespace Evently.Modules.Events.Domain.TicketTypes.DomainEvents;

public sealed class TicketTypeCreatedDomainEvent : DomainEvent
{
    public required Guid TicketTypeId { get; init; }
}