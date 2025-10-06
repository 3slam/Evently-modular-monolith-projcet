using Evently.Modules.Ticketing.Domain.Tickets.Models;

namespace Evently.Modules.Ticketing.Application.Tickets;

public sealed record TicketResponse(
    Guid Id,
    Guid CustomerId,
    Guid OrderId,
    Guid EventId,
    Guid TicketTypeId,
    string? Code,
    DateTime CreatedAtUtc,
    bool Archived)
{
    public static implicit operator TicketResponse(Ticket ticket) =>
        new TicketResponse(
            ticket.Id,
            ticket.CustomerId,
            ticket.OrderId,
            ticket.EventId,
            ticket.TicketTypeId,
            ticket.Code,
            ticket.CreatedAtUtc,
            ticket.Archived
        );
}