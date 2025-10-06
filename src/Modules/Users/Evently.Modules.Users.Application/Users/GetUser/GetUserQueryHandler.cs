namespace Evently.Modules.Users.Application.Users.GetUser;

internal sealed class GetUserQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUserQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(request.UserId);
        if (user is null)
            return UserErrors.NotFound(request.UserId);

        return (UserResponse) user;
    }
}