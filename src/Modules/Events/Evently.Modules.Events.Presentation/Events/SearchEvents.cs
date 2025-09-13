
using Evently.Modules.Events.Application.Events.SearchEvents;

namespace Evently.Modules.Events.Presentation.Events;

public class SearchEvents : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("events/search", async (string? title, DateTime? startsAtUtc, ISender sender) =>
        {
            var result = await sender.Send(new SearchEventsQuery(title, startsAtUtc));
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Error);
        })
        .WithName(EventEndpointMetadata.SearchEvents)
        .WithTags(EventEndpointMetadata.Tag);
    }
}
