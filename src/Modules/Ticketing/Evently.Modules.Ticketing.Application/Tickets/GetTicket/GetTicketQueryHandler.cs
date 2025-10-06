using Evently.Common.Application.Messaging;
using Evently.Common.Domain.ResultPattern;
using Evently.Modules.Ticketing.Domain.Tickets.Models;
using Evently.Modules.Ticketing.Domain.Tickets.Repository;

namespace Evently.Modules.Ticketing.Application.Tickets.GetTicket;

internal sealed class GetTicketQueryHandler(ITicketRepository ticketRepository) 
    : IQueryHandler<GetTicketQuery, TicketResponse>
{
    public async Task<Result<TicketResponse>> Handle(GetTicketQuery request, CancellationToken cancellationToken)
    {
        var ticket = await ticketRepository.GetAsync(request.TicketId, cancellationToken);

        if (ticket is null)
            return TicketErrors.NotFound(request.TicketId);

        return (TicketResponse)ticket;
    }
}