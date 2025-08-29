using Evently.Common.Domain.Events;

namespace Evently.Modules.Events.Domain.Events.DomainEvents;

public sealed class EventRescheduledDomainEvent : DomainEvent
{
    public required Guid EventId { get; init; }
    public required DateTime StartsAtUtc { get; init; }  
    public required DateTime? EndsAtUtc { get; init; } 
}
 