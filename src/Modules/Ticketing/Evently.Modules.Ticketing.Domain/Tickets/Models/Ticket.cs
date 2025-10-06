using Evently.Common.Domain.BaseEntity;
using Evently.Modules.Ticketing.Domain.Tickets.DomainEvents;

namespace Evently.Modules.Ticketing.Domain.Tickets.Models;

public sealed class Ticket : Entity
{
    private Ticket() { }

    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid EventId { get; private set; }
    public Guid TicketTypeId { get; private set; }
    public string? Code { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }
    public bool Archived { get; private set; }
    
    public static Ticket Create(Guid customerId, Guid orderId, Guid eventId, Guid ticketTypeId)
    {
        var ticket = new Ticket
        {
            Id = Guid.CreateVersion7(),
            CustomerId = customerId,
            OrderId = orderId,
            EventId = eventId,
            TicketTypeId = ticketTypeId,
            Code = $"tc_{Guid.NewGuid()}",
            CreatedAtUtc = DateTime.UtcNow
        };

        ticket.RaiseDomainEvent(new TicketCreatedDomainEvent(ticket.Id));

        return ticket;
    }
    
    public void Archive()
    {
        if (Archived)
            return;

        Archived = true;
        RaiseDomainEvent(new TicketArchivedDomainEvent(Id, Code!));
    }
}
