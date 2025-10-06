using Evently.Common.Application.Messaging;
using Evently.Common.Domain.ResultPattern;
using Evently.Modules.Ticketing.Domain.Tickets.Repository;

namespace Evently.Modules.Ticketing.Application.Tickets.GetTickets;

internal sealed class GetTicketsQueryHandler(ITicketRepository ticketRepository) 
    : IQueryHandler<GetTicketsQuery, IReadOnlyCollection<TicketResponse>>
{
    public async Task<Result<IReadOnlyCollection<TicketResponse>>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Domain.Tickets.Models.Ticket> tickets;

        if (request.CustomerId.HasValue)
        {
            tickets = await ticketRepository.GetByCustomerIdAsync(request.CustomerId.Value, cancellationToken);
        }
        else if (request.EventId.HasValue)
        {
            tickets = await ticketRepository.GetByEventIdAsync(request.EventId.Value, cancellationToken);
        }
        else
        {
            tickets = await ticketRepository.GetAllAsync(cancellationToken);
        }

        var response = tickets.Select(t => (TicketResponse)t).ToList();
        return Result.Success<IReadOnlyCollection<TicketResponse>>(response);
    }
}