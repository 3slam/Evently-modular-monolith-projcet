using Evently.Modules.Ticketing.Application.Tickets.GetTicket;
using Evently.Common.Presentation.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MediatR;
using Evently.Modules.Ticketing.Presentation.Utilities;

namespace Evently.Modules.Ticketing.Presentation.Tickets;

internal sealed class GetTicket : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("tickets/{ticketId}", async (Guid ticketId, ISender sender) =>
        {
            var result = await sender.Send(new GetTicketQuery(ticketId));
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        })
        .WithTags(TicketEndpointMetadata.Tag)
        .WithName(TicketEndpointMetadata.GetTicket);
    }
}