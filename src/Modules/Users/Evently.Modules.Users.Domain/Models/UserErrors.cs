using Evently.Common.Domain.Erros;

namespace Evently.Modules.Users.Domain.Models;

public static class UserErrors
{
    public static Error NamesShouldNotBeEmpty()
        => Error.Validation("Users.NamesShouldNotBeEmpty", "Names should not be empty");
    
    public static Error NotFound(Guid userId)
        => Error.NotFound("Users.NotFound", $"User with Id '{userId}' was not found");
}