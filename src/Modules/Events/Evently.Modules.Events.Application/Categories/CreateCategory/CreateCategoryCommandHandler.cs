
namespace Evently.Modules.Events.Application.Categories.CreateCategory;

public sealed class CreateCategoryCommandHandler(
    IUnitOfWork unitOfWork,
    ICategoryRepository categoryRepository,
    IValidator<CreateCategoryCommand> validator): IRequestHandler<CreateCategoryCommand, Result<CategoryResponse>>
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