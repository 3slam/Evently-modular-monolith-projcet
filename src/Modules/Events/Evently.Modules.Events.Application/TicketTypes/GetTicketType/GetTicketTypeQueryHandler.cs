namespace Evently.Modules.Events.Application.TicketTypes.GetTicketType;

public sealed class GetTicketTypeQueryHandler(ITicketTypeRepository ticketTypeRepository) 
    : IRequestHandler<GetTicketTypeQuery, Result<TicketTypeResponse>>
{
    public async Task<Result<TicketTypeResponse>> Handle(GetTicketTypeQuery request, CancellationToken cancellationToken)
    {
        var ticketType = await ticketTypeRepository.GetAsync(request.TicketTypeId, cancellationToken);

        if (ticketType is null)
            return TicketTypeErrors.NotFound(request.TicketTypeId);

        return (TicketTypeResponse) ticketType;
    }
}