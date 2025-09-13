using Evently.Common.Domain.Erros;

namespace Evently.Modules.Events.Domain.TicketTypes.Models;

public static class TicketTypeErrors
{
    public static Error NotFound(Guid ticketTypeId) 
        => Error.NotFound("TicketTypes.NotFound", $"The ticket type with the identifier {ticketTypeId} was not found");

    public static Error Validation(string? message) => Error.Validation("TicketTypes.Validation", message ?? "Validation failed for ticket type");
}