using Evently.Modules.Events.Application.Events.PublishEvent;

namespace Evently.Modules.Events.Presentation.Events;

public class PublishEvent : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPatch("events/{eventId}/publish", async (Guid eventId, ISender sender) =>
        {
            var result = await sender.Send(new PublishEventCommand(eventId));
            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
        })
        .WithName(EventEndpointMetadata.PublishEvent)
        .WithTags(EventEndpointMetadata.Tag);
    }
}
