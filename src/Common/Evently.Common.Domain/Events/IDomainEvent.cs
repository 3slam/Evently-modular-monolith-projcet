namespace Evently.Common.Domain.Events;

public interface IDomainEvent
{
    //identifier of the domain event itself used for event store, message bus, deduplication not realted  to the event module
    public Guid Id { get; init; } 
    public DateTime OccurredAtUtc { get; init; }
}
 