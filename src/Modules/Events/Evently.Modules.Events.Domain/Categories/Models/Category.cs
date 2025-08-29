using Evently.Common.Domain.BaseEntity;
using Evently.Common.Domain.ResultPattern;
using Evently.Modules.Events.Domain.Categories.DomainEvents;

namespace Evently.Modules.Events.Domain.Categories.Models;

public class Category : Entity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public bool IsArchived { get; private set; }

    private Category() { }

    public static Category Create(string name)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = name,
            IsArchived = false
        };

        category.RaiseDomainEvent(new CategoryCreatedDomainEvent() { CategoryId = category.Id });

        return category;
    }

    public Result Archive()
    {
        if (IsArchived)
            return CategoryErrors.AlreadyArchived;

        IsArchived = true;

        RaiseDomainEvent(new CategoryArchivedDomainEvent() { CategoryId = Id });

        return Result.Success();
    }

    public void ChangeName(string name)
    {
        if (Name == name) return;

        Name = name;

        RaiseDomainEvent(new CategoryNameChangedDomainEvent() { CategoryId = Id , Name = name });
    }
}
