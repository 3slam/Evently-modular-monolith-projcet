using Evently.Common.Domain.BaseEntity;

namespace Evently.Modules.Ticketing.Domain.TicketsType;

public sealed class TicketType : Entity
{
    private TicketType()
    {
    }

    public Guid Id { get; private set; }

    public Guid EventId { get; private set; }

    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public string Currency { get; private set; }

    public decimal Quantity { get; private set; }

    public decimal AvailableQuantity { get; private set; }

    public static TicketType Create(
        Guid id,
        Guid eventId,
        string name,
        decimal price,
        string currency,
        decimal quantity)
    {
        var ticketType = new TicketType
        {
            Id = id,
            EventId = eventId,
            Name = name,
            Price = price,
            Currency = currency,
            Quantity = quantity,
            AvailableQuantity = quantity
        };

        return ticketType;
    }
}
