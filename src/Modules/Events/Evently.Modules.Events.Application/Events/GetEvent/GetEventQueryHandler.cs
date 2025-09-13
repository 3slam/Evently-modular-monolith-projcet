

namespace Evently.Modules.Events.Application.Events.GetEvent;

public sealed class GetEventQueryHandler(
    IEventRepository eventRepository,
    IValidator<GetEventQuery> validator) : IRequestHandler<GetEventQuery, Result<EventResponse>>
{
    public async Task<Result<EventResponse>> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return EventErrors.NotValid(validationResult.Errors.FirstOrDefault()?.ErrorMessage);

        var @event = await eventRepository.GetAsync(request.EventId, cancellationToken);

        if (@event is null)
            return EventErrors.NotFound(request.EventId);

        return (EventResponse)@event;
    }
}
