namespace Evently.Modules.Events.Application.TicketTypes.GetTicketTypes;

public sealed class GetTicketTypesQueryHandler(ITicketTypeRepository ticketTypeRepository)
    : IRequestHandler<GetTicketTypesQuery, Result<IReadOnlyCollection<TicketTypeResponse>>>
{
    public async Task<Result<IReadOnlyCollection<TicketTypeResponse>>> Handle(GetTicketTypesQuery request, CancellationToken cancellationToken)
    {
        var ticketTypes = await ticketTypeRepository.GetByEventIdAsync(request.EventId, cancellationToken);
        var response = ticketTypes.Select(t => (TicketTypeResponse)t).ToList();
        return response;
    }
}