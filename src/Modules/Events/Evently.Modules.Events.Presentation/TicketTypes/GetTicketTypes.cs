using Evently.Modules.Events.Application.TicketTypes.GetTicketTypes;

namespace Evently.Modules.Events.Presentation.TicketTypes;

public class GetTicketTypes : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{eventId}/ticket-types", async (Guid eventId, ISender sender) =>
        {
            var result = await sender.Send(new GetTicketTypesQuery(eventId));
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        })
        .WithName(TicketTypeEndpointMetadata.GetTicketTypes)
        .WithTags(TicketTypeEndpointMetadata.Tag);
    }
}