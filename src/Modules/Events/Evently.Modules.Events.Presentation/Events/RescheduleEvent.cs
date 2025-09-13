using Evently.Modules.Events.Application.Events.RescheduleEvent;

namespace Evently.Modules.Events.Presentation.Events;

public class RescheduleEvent : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPatch("events/{eventId}/reschedule", async (RescheduleEventRequest request, ISender sender) =>
        {
            var command = new RescheduleEventCommand(request.EventId, request.StartsAtUtc, request.EndsAtUtc);
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
        })
        .WithName(EventEndpointMetadata.RescheduleEvent)
        .WithTags(EventEndpointMetadata.Tag);
    }

    public sealed record RescheduleEventRequest(
        Guid EventId,
        DateTime StartsAtUtc,
        DateTime? EndsAtUtc);
}
