using Evently.Common.Application.Messaging;

namespace Evently.Modules.Ticketing.Application.Tickets.GetTickets;

public sealed record GetTicketsQuery(Guid? CustomerId = null, Guid? EventId = null) : IQuery<IReadOnlyCollection<TicketResponse>>;