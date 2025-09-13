namespace Evently.Modules.Events.Application.Events.PublishEvent;

internal sealed class PublishEventCommandHandler(
    IEventRepository eventRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<PublishEventCommand, Result<EventResponse>>
{
    public async Task<Result<EventResponse>> Handle(PublishEventCommand request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetAsync(request.EventId, cancellationToken);
        if (@event is null)
            return EventErrors.NotFound(request.EventId);

        var result = @event.Publish();
        if (result.IsFailure)
            return result.Error;
  
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return (EventResponse)@event;
    }
}
