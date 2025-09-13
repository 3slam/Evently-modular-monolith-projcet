using Evently.Modules.Events.Application.TicketTypes.GetTicketType;

namespace Evently.Modules.Events.Presentation.TicketTypes;

internal class GetTicketType : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("ticket-types/{ticketTypeId}", async (Guid ticketTypeId, ISender sender) =>
        {
            var result = await sender.Send(new GetTicketTypeQuery(ticketTypeId));
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        })
        .WithTags(TicketTypeEndpointMetadata.Tag)
        .WithName(TicketTypeEndpointMetadata.GetTicketType);
    }
}