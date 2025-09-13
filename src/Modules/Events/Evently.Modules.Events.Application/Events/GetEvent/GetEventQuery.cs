namespace Evently.Modules.Events.Application.Events.GetEvent;

public sealed record GetEventQuery(Guid EventId) :IRequest<Result<EventResponse>>;
