using Evently.Modules.Events.Domain.Categories.Models;
using Evently.Modules.Events.Domain.Categories.Repository;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Infrastructure.Categories;

internal sealed class CategoryRepository(EventsDbContext db) : ICategoryRepository
{
    public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
    {
        await db.Categories.AddAsync(category, cancellationToken);
    }

    public async Task<Category?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await db.Categories.SingleOrDefaultAsync(category => category.Id == id, cancellationToken);
    }

    public void Update(Category category)
    {
        db.Categories.Update(category);
    }

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await db.Categories.ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Category category, CancellationToken cancellationToken = default)
    {
        db.Categories.Update(category);
        await db.SaveChangesAsync(cancellationToken);
    }
}