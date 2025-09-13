
using Evently.Modules.Events.Application.Events.GetEvents;

namespace Evently.Modules.Events.Presentation.Events;

public class GetEvents : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("events", async (ISender sender) =>
        {
            var result = await sender.Send(new GetEventsQuery());
            return Results.Ok(result);
        })
        .WithName(EventEndpointMetadata.GetEvents)
        .WithTags(EventEndpointMetadata.Tag);
    }
}
