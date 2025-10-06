namespace Evently.Modules.Users.Application.Users.CreateUser;

public sealed record CreateUserCommand(
    string? FirstName,
    string? LastName) : ICommand<UserResponse>;