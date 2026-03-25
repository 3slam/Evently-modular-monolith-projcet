using Evently.Common.Domain.BaseEntity;

namespace Evently.Modules.Ticketing.Domain.Customers;

public sealed class Customer : Entity
{
    private Customer()
    {
    }

    public Guid Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public static Customer Create(Guid id, string firstName, string lastName)
    {
        return new Customer
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName
        };
    }

    public void Update(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
