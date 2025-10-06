namespace Evently.Modules.Users.Application.Users.UpdateUser;

internal sealed class UpdateUserCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserCommand, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(request.UserId);
        if (user is null)
        {
            return UserErrors.NotFound(request.UserId);
        }

        var updateResult = user.Update(request.FirstName, request.LastName, null, null);
        if (updateResult.IsFailure)
        {
            return UserErrors.NotFound(request.UserId);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return (UserResponse)updateResult.Value;
    }
}