using Evently.Modules.Users.Domain.Models;
using Evently.Modules.Users.Domain.Repository;
using Evently.Modules.Users.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Users.Infrastructure.Repository;

internal class UserRepository(UserDbContext context) : IUserRepository
{
    public async Task AddAsync(User user) => await context.AddAsync(user); 
    public async Task<User?> GetAsync(Guid id) => await context.Users.SingleOrDefaultAsync(user => user.Id == id);
}
