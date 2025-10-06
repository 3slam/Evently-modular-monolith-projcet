using Evently.Modules.Users.Application.Users.UpdateUser;

namespace Evently.Modules.Users.Presentation.Users;

internal sealed class UpdateUser : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("users/{userId:guid}", async (Guid userId, UpdateUserRequest request, ISender sender) =>
        {
            var command = new UpdateUserCommand(
                userId,
                request.FirstName,
                request.LastName);

            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);

        }).WithName(UserEndpointMetadata.UpdateUser)
          .WithTags(UserEndpointMetadata.Tag);
    }

    internal sealed record UpdateUserRequest(
        string? FirstName,
        string? LastName);
}