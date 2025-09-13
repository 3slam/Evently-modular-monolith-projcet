namespace Evently.Modules.Events.Application.Events.GetEvents;

public sealed record GetEventsQuery() : IRequest<Result<IReadOnlyCollection<EventResponse>>>;
