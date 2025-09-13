using Evently.Modules.Events.Application.Events.GetEvent;

namespace Evently.Modules.Events.Presentation.Events;

internal class GetEvent : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{eventId}", async (Guid eventId, ISender sender) =>
        {
            var result = await sender.Send(new GetEventQuery(eventId));
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Error);

        })
          .WithTags(EventEndpointMetadata.Tag)
          .WithName(EventEndpointMetadata.GetEvent);
    }
}
