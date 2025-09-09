

namespace Evently.Modules.Events.Application.Events.GetEvents;

public sealed record GetEventQuery(Guid EventId) :IRequest<Result<EventResponse>>;
