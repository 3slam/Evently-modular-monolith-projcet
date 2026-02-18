using Evently.Modules.Events.Domain.Events.DomainEvents;
using Microsoft.Extensions.Logging;

namespace Evently.Modules.Events.Application.Events.CancelEvent;

internal sealed class CancelEventDomainEventHandler(ILogger<CancelEventDomainEventHandler> logger) : IDomainEventHandler<EventCancelledDomainEvent>
{
    public Task Handle(EventCancelledDomainEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Event cancelled");
        throw new NotImplementedException();
    }
}