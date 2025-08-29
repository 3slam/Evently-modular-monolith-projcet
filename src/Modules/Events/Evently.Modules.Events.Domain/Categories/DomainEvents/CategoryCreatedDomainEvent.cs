using Evently.Common.Domain.Events;

namespace Evently.Modules.Events.Domain.Categories.DomainEvents;

public sealed class CategoryCreatedDomainEvent : DomainEvent
{
    public required Guid CategoryId { get; init; }
}
