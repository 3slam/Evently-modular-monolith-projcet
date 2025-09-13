namespace Evently.Modules.Events.Application.Events.RescheduleEvent;

internal sealed class RescheduleEventCommandHandler(
    IEventRepository eventRepository , IUnitOfWork unitOfWork) : IRequestHandler<RescheduleEventCommand, Result<EventResponse>>
{
    public async Task<Result<EventResponse>> Handle(RescheduleEventCommand request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetAsync(request.EventId, cancellationToken);
        if (@event is null)
            return EventErrors.NotFound(request.EventId);

        var result = @event.Reschedule(request.StartsAtUtc, request.EndsAtUtc);

        if (result.IsFailure)
            return result.Error;

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return (EventResponse)@event;
    }
}
