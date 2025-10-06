using Evently.Modules.Users.Application.Users.GetUser;

namespace Evently.Modules.Users.Presentation.Users;

internal sealed class GetUser : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("users/{userId:guid}", async (Guid userId, ISender sender) =>
        {
            var query = new GetUserQuery(userId);

            var result = await sender.Send(query);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound(result.Error);

        }).WithName(UserEndpointMetadata.GetUser)
          .WithTags(UserEndpointMetadata.Tag);
    }
}