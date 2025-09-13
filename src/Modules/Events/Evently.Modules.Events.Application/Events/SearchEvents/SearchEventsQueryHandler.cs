namespace Evently.Modules.Events.Application.Events.SearchEvents;

internal sealed class SearchEventsQueryHandler(
    IEventRepository eventRepository) : IRequestHandler<SearchEventsQuery, Result<IReadOnlyCollection<EventResponse>>>
{

    public async Task<Result<IReadOnlyCollection<EventResponse>>> Handle(SearchEventsQuery request, CancellationToken cancellationToken)
    {
        var events = await eventRepository.SearchAsync(request.Title, request.StartsAtUtc, cancellationToken);
        return events.Select(e => (EventResponse)e).ToList();
    }
}
