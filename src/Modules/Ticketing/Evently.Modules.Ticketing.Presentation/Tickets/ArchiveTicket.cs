using Evently.Common.Presentation.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Evently.Modules.Ticketing.Presentation.Utilities;
using MediatR;
using Evently.Modules.Ticketing.Application.Tickets.ArchiveTicket;

namespace Evently.Modules.Ticketing.Presentation.Tickets;

public sealed class ArchiveTicket : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("tickets/{ticketId}/archive", async (Guid ticketId, ISender sender) =>
        {
            var command = new ArchiveTicketCommand(ticketId);
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
        })
        .WithName(TicketEndpointMetadata.ArchiveTicket)
        .WithTags(TicketEndpointMetadata.Tag);
    }
}