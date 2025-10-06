using Evently.Common.Domain.Erros;

namespace Evently.Modules.Ticketing.Domain.Tickets.Models;

public static class TicketErrors
{
    public static Error NotFound(Guid ticketId) => Error.NotFound("Tickets.NotFound", $"Ticket with id {ticketId} not found");
    public static Error NotFound(string code) => Error.NotFound("Tickets.NotFound", $"Ticket with code {code} not found");
}