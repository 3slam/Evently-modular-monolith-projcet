

namespace Evently.Modules.Events.Application.Events.GetEvents;

public sealed class GetEventQueryHandler(IEventRepository eventRepository) 
    : IRequestHandler<GetEventQuery, Result<EventResponse>>
{
    public async Task<Result<EventResponse>> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetAsync(request.EventId, cancellationToken);
        if (@event is null)
        {
            return Error.NotFound("Events.NotFound", $"The event with the identifier {request.EventId} was not found");
        }

       return (EventResponse)@event;
    }
}
