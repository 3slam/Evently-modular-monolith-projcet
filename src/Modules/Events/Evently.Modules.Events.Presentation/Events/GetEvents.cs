
using Evently.Common.Application.Cache;
using Evently.Common.Domain.ResultPattern;
using Evently.Modules.Events.Application.Events.GetEvents;

namespace Evently.Modules.Events.Presentation.Events;

public class GetEvents : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("events", async (ISender sender,ICacheService cacheService) =>
        {
            var cachedEvents = await cacheService.GetAsync<List<EventResponse>>("eventsList");
            if (cachedEvents is not null)
                return Results.Ok(Result.Success(cachedEvents));

            var result = await sender.Send(new GetEventsQuery());
            await cacheService.SetAsync("eventsList", result.Value.ToList(), expirationInMinutes: 10);
            return Results.Ok(result);
        })
        .WithName(EventEndpointMetadata.GetEvents)
        .WithTags(EventEndpointMetadata.Tag);
    }
}
