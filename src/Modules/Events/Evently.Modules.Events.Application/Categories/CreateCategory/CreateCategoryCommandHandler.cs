
using Evently.Modules.Events.Domain.Categories.DomainEvents;
using Evently.Modules.Events.Domain.Events.DomainEvents;

namespace Evently.Modules.Events.Application.Categories.CreateCategory;

public sealed class CreateCategoryCommandHandler(
    IUnitOfWork unitOfWork,
    ICategoryRepository categoryRepository,
    IValidator<CreateCategoryCommand> validator): ICommandHandler<CreateCategoryCommand, CategoryResponse>
{
    public async Task<Result<CategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return CategoryErrors.Validation(validationResult.Errors.FirstOrDefault()?.ErrorMessage);

        var category = Category.Create(request.Name);
        await categoryRepository.AddAsync(category, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return (CategoryResponse)category;
    }
}

internal sealed class CreateCategoryDomainEventHandler : INotificationHandler<CategoryCreatedDomainEvent>
{
    public Task Handle(CategoryCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Category created" + notification.CategoryId , notification.Id , notification.OccurredAtUtc);
        return Task.CompletedTask;
    }
}