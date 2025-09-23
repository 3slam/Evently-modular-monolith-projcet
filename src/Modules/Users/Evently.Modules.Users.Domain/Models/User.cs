using Evently.Common.Domain.BaseEntity;
using Evently.Common.Domain.ResultPattern;
using Evently.Modules.Users.Domain.DomainEvent;

namespace Evently.Modules.Users.Domain.Models;

public sealed class User : Entity
{
    public Guid Id { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }


    public static Result<User> Create(string? firstName, string? lastName)
    {
        var user =  new User
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName
        };

      user.RaiseDomainEvent(new CreateUserDomainEvent(user.Id));

      return user;
    }

    public Result<User> Update(string? firstName, string? lastName, string? email, string? password)
    {
        if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName) )
            return UserErrors.NamesShouldNotBeEmpty();

        if (firstName == FirstName && lastName == LastName)
            return this;

        FirstName = firstName;
        LastName = lastName;
      
        RaiseDomainEvent(new UpdateUserDomainEvent(Id!));
        return this;
    }
}
