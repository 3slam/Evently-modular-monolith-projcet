using Evently.Modules.Events.Domain.Events.DomainEvents;
using Microsoft.Extensions.Logging;

namespace Evently.Modules.Events.Application.Events.RescheduleEvent;

internal sealed class EventRescheduledDomainEventHandler(ILogger<EventRescheduledDomainEventHandler> logger) 
    : IDomainEventHandler<EventRescheduledDomainEvent>
{
    public Task Handle(EventRescheduledDomainEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Event Rescheduled");
        return Task.CompletedTask;
        //throw new NotImplementedException();
    }
}