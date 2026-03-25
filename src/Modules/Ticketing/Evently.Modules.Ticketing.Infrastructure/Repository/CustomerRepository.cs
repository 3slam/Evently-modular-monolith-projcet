using Evently.Modules.Ticketing.Domain.Customers;
using Evently.Modules.Users.UsersApi;

namespace Evently.Modules.Ticketing.Infrastructure.Repository;

internal class CustomerRepository(IUserApi api) : ICustomerRepository
{
    public async Task<Customer?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await api.GetUserAsync(id);
        if (user is null)
            return null;

        return Customer.Create(user.Id, user.FirstName, user.LastName);
    }

    public void Insert(Customer customer)
    {
        throw new NotImplementedException();
    }
}