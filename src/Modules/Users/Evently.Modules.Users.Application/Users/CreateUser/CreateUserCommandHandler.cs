namespace Evently.Modules.Users.Application.Users.CreateUser;

internal sealed class CreateUserCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userResult = User.Create(request.FirstName, request.LastName);
        if (userResult.IsFailure)
        {
            return userResult.Error;
        }

        await userRepository.AddAsync(userResult.Value);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return (UserResponse)userResult.Value;
    }
}