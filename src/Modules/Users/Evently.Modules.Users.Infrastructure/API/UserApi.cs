using Evently.Modules.Users.Application.Users.GetUser;
using Evently.Modules.Users.Domain.Repository;
using Evently.Modules.Users.UsersApi;
using MediatR;

namespace Evently.Modules.Users.Infrastructure.API;

internal class UserApi(ISender sender) : IUserApi
{
    public async Task<UserReponse?> GetUserAsync(Guid id)
    {
        var user = await sender.Send(new GetUserQuery(id));

        if (user.IsFailure)
        {
            return null;
        }

        return new UserReponse(user.Value.Id, user.Value.FirstName, user.Value.LastName);
    }
}
