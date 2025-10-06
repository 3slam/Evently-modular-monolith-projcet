using Evently.Common.Application.Messaging;

namespace Evently.Modules.Ticketing.Application.Tickets.ArchiveTicket;

public sealed record ArchiveTicketCommand(Guid TicketId) : ICommand;