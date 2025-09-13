namespace Evently.Modules.Events.Application.Events.CancelEvent;

internal sealed class CancelEventCommandHandler(
    IUnitOfWork unitOfWork,
    IEventRepository eventRepository,
    IDateTimeProvider dateTimeProvider,
    IValidator<CancelEventCommand> validator) : IRequestHandler<CancelEventCommand, Result<EventResponse>>
{
    public async Task<Result<EventResponse>> Handle(CancelEventCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return EventErrors.NotValid(validationResult.Errors.FirstOrDefault()?.ErrorMessage);

        var @event = await eventRepository.GetAsync(request.EventId, cancellationToken);
        if (@event is null)
            return EventErrors.NotFound(request.EventId);

        var cancelResult = @event.Cancel(dateTimeProvider.UtcNow);

        if (cancelResult.IsFailure)
           return cancelResult.Error;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return (EventResponse)@event;
    }
}
