using Evently.Modules.Events.Application.Events.GetEvents;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events;

internal static class GetEvent
{
    public static void MapGetEvent(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{eventId}", async (Guid eventId, ISender sender) =>
        {
            var result = await sender.Send(new GetEventQuery(eventId));

            if (result.IsSuccess)
            {
                return Results.Ok(result.Value);
            }
            else
            { 
                return Results.NotFound(result.Error); 
            }
        });
    }
    
}
