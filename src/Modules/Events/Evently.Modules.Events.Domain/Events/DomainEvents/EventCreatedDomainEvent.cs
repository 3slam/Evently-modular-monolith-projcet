using Evently.Common.Domain.Events;

namespace Evently.Modules.Events.Domain.Events.DomainEvents;

public sealed class EventCreatedDomainEvent : DomainEvent
{
    public required Guid EventId { get; init; }
}
 