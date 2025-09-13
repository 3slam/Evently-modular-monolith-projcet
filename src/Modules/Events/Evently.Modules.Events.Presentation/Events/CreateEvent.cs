using Evently.Modules.Events.Application.Events.CreateEvent;

namespace Evently.Modules.Events.Presentation.Events;

internal sealed class CreateEvent : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async (CreateEventRequest request, ISender sender) =>
        {
            var command = new CreateEventCommand(
                request.CategoryId,
                request.Title,
                request.Description,
                request.Location,
                request.StartsAtUtc,
                request.EndsAtUtc);

            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Error);

        }).WithName(EventEndpointMetadata.CancelEvent)
          .WithTags(EventEndpointMetadata.Tag);
    }

    internal sealed record CreateEventRequest(
        Guid CategoryId,
        string Title,
        string Description,
        string Location,
        DateTime StartsAtUtc,
        DateTime? EndsAtUtc);
}
