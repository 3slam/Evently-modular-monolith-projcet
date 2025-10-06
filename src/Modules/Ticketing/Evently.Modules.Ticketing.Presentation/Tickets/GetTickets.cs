using Evently.Modules.Ticketing.Application.Tickets.GetTickets;
using Evently.Common.Presentation.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MediatR;
using Evently.Modules.Ticketing.Presentation.Utilities;

namespace Evently.Modules.Ticketing.Presentation.Tickets;

public sealed class GetTickets : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("tickets", async (Guid? customerId, Guid? eventId, ISender sender) =>
        {
            var result = await sender.Send(new GetTicketsQuery(customerId, eventId));
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        })
        .WithName(TicketEndpointMetadata.GetTickets)
        .WithTags(TicketEndpointMetadata.Tag);
    }
}