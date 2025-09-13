namespace Evently.Modules.Events.Application.Events.GetEvents;

internal sealed class GetEventsQueryHandler(IEventRepository eventRepository) 
    : IRequestHandler<GetEventsQuery, Result<IReadOnlyCollection<EventResponse>>>
{
 
    public async Task<Result<IReadOnlyCollection<EventResponse>>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        var events = await eventRepository.GetAllAsync(cancellationToken);
        return events.Select(e => (EventResponse)e).ToList();
    }
}
