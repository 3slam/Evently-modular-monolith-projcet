namespace Evently.Modules.Events.Application.TicketTypes.GetTicketTypes;

public sealed record GetTicketTypesQuery(Guid EventId) : IRequest<Result<IReadOnlyCollection<TicketTypeResponse>>>;