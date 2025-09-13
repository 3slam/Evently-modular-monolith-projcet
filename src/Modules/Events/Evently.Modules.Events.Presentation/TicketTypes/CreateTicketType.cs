using Evently.Modules.Events.Application.TicketTypes.CreateTicketType;

namespace Evently.Modules.Events.Presentation.TicketTypes;

internal sealed class CreateTicketType : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("events/{eventId}/ticket-types", async (Guid eventId, CreateTicketTypeRequest request, ISender sender) =>
        {
            var command = new CreateTicketTypeCommand(
                eventId,
                request.Name,
                request.Price,
                request.Currency,
                request.Quantity);
            
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        })
        .WithName(TicketTypeEndpointMetadata.CreateTicketType)
        .WithTags(TicketTypeEndpointMetadata.Tag);
    }

    internal sealed record CreateTicketTypeRequest(
        string Name,
        decimal Price,
        string Currency,
        decimal Quantity);
}