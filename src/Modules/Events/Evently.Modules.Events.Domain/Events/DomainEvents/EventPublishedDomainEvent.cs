using Evently.Common.Domain.Events;

namespace Evently.Modules.Events.Domain.Events.DomainEvents;

public sealed class EventPublishedDomainEvent : DomainEvent
{
    public required Guid EventId { get; init; }
}
 