namespace Evently.Modules.Events.Application.Events.CancelEvent;

public sealed record CancelEventCommand(Guid EventId) : IRequest<Result<EventResponse>>;
