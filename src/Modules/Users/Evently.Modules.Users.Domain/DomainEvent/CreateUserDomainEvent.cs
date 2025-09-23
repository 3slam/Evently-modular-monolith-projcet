namespace Evently.Modules.Users.Domain.DomainEvent;

public sealed class CreateUserDomainEvent(Guid Id) : Common.Domain.Events.DomainEvent
{
    public Guid UserId { get; } = Id;
}
