using Evently.Common.Application.Abstraction.Data;
using Evently.Common.Application.Messaging;
using Evently.Common.Domain.ResultPattern;
using Evently.Modules.Ticketing.Domain.Tickets.Models;
using Evently.Modules.Ticketing.Domain.Tickets.Repository;
namespace Evently.Modules.Ticketing.Application.Tickets.ArchiveTicket;

internal sealed class ArchiveTicketCommandHandler(
    ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<ArchiveTicketCommand>
{
    public async Task<Result> Handle(ArchiveTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await ticketRepository.GetAsync(request.TicketId, cancellationToken);

        if (ticket is null)
            return TicketErrors.NotFound(request.TicketId);

        ticket.Archive();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}