using Evently.Modules.Users.Application.Users.CreateUser;

namespace Evently.Modules.Users.Presentation.Users;

internal sealed class CreateUser : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("users", async (CreateUserRequest request, ISender sender) =>
        {
            var command = new CreateUserCommand(
                request.FirstName,
                request.LastName);

            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Error);

        }).WithName(UserEndpointMetadata.CreateUser)
          .WithTags(UserEndpointMetadata.Tag);
    }

    internal sealed record CreateUserRequest(
        string? FirstName,
        string? LastName);
}