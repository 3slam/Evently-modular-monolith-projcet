using Evently.Common.Presentation.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Evently.Modules.Ticketing.Presentation.Utilities;
using MediatR;
using Evently.Modules.Ticketing.Application.Carts.AddItemToCart;

namespace Evently.Modules.Ticketing.Presentation.Carts;

public sealed class AddItemToCart : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("cart", async (AddItemToCartCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
        })
        .WithName(CartEndpointMetadata.AddItemToCart)
        .WithTags(CartEndpointMetadata.Tag);
    }
}