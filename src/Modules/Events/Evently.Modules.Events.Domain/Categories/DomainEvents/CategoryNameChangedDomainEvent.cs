using Evently.Common.Domain.Events;

namespace Evently.Modules.Events.Domain.Categories.DomainEvents;

public sealed class CategoryNameChangedDomainEvent : DomainEvent
{
    public required Guid CategoryId { get; init; } 
    public required string Name { get; init; } 
}
