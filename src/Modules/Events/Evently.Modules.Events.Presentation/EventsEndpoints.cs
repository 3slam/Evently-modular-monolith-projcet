using Evently.Modules.Events.Presentation.Events;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation;

public static class EventsEndpoints
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        CreateEvent.MapCreateEvent(app);
    }
}
