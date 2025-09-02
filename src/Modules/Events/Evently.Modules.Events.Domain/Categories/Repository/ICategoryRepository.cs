using Evently.Modules.Events.Domain.Categories.Models;

namespace Evently.Modules.Events.Domain.Categories.Repository;

public interface ICategoryRepository
{
    Task<Category?> GetAsync(Guid id , CancellationToken cancellationToken = default);
    Task AddAsync(Category category, CancellationToken cancellationToken = default);
    void Update(Category category);
}
