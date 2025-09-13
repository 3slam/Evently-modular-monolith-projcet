using MediatR;

namespace Evently.Modules.Events.Application.Events.PublishEvent;

public sealed record PublishEventCommand(Guid EventId) : IRequest<Result<EventResponse>>;
