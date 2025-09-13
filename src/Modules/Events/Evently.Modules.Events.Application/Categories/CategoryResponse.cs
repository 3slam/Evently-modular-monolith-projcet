using Evently.Modules.Events.Domain.Categories.Models;

namespace Evently.Modules.Events.Application.Categories;

public sealed record CategoryResponse(Guid Id,string Name,bool IsArchived)
{
    public static implicit operator CategoryResponse(Category category) => new(category.Id,category.Name,category.IsArchived);
}