namespace Evently.Modules.Events.Application.Events.CreateEvent;

public sealed class CreateEventCommandHandler(
    IUnitOfWork unitOfWork,
    IEventRepository eventRepository,
    IValidator<CreateEventCommand> validator) : IRequestHandler<CreateEventCommand, Result<EventResponse>>
{
    public async Task<Result<EventResponse>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
             return Result.Failure<EventResponse>(new Error("Events.CreateEvent.Failure", 
                 validationResult.Errors.FirstOrDefault()?.ErrorMessage ?? string.Empty,
                 ErrorType.Validation));
        }

       var @event = Event.CreateDraft(
            request.CategoryId,
            request.Title,
            request.Description,
            request.Location,
            request.StartsAtUtc,
            request.EndsAtUtc);

        if (@event.IsFailure)
            return Result.Failure<EventResponse>(@event.Error);

        await eventRepository.AddAsync(@event, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return (EventResponse) @event.Value;
    }
}
