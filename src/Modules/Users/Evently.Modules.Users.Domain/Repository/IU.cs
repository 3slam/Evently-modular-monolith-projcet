using Evently.Modules.Users.Domain.Models;

namespace Evently.Modules.Users.Domain.Repository;

public interface IUserRepository
{
    Task<User?> GetAsync(Guid id);
    Task AddAsync(User user);
}
