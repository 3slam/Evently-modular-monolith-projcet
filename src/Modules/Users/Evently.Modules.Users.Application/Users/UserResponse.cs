namespace Evently.Modules.Users.Application.Users;

public sealed record UserResponse(
    Guid Id,
    string? FirstName,
    string? LastName)
{
    public static explicit operator UserResponse(User user) =>
        new(user.Id,
            user.FirstName,
            user.LastName);
}