using Evently.Modules.Events.Application.TicketTypes.UpdateTicketTypePrice;

namespace Evently.Modules.Events.Presentation.TicketTypes;

public class UpdateTicketTypePrice : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("ticket-types/{ticketTypeId}/price", async (Guid ticketTypeId, UpdateTicketTypePriceRequest request, ISender sender) =>
        {
            var command = new UpdateTicketTypePriceCommand(ticketTypeId, request.Price);
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        })
        .WithName(TicketTypeEndpointMetadata.UpdateTicketTypePrice)
        .WithTags(TicketTypeEndpointMetadata.Tag);
    }

    public sealed record UpdateTicketTypePriceRequest(decimal Price);
}