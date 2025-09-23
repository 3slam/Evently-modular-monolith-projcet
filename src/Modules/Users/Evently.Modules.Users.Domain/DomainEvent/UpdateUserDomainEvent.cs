namespace Evently.Modules.Users.Domain.DomainEvent;

public sealed class UpdateUserDomainEvent(Guid Id) : Common.Domain.Events.DomainEvent
{
    public Guid UserId { get; } = Id;
}
