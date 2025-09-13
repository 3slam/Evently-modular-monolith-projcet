namespace Evently.Modules.Events.Application.Categories.UpdateCategory;

public sealed class UpdateCategoryCommandHandler(
    IUnitOfWork unitOfWork,
    ICategoryRepository categoryRepository,
    IValidator<UpdateCategoryCommand> validator) : IRequestHandler<UpdateCategoryCommand, Result<CategoryResponse>>
{
    public async Task<Result<CategoryResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return CategoryErrors.Validation(validationResult.Errors.FirstOrDefault()?.ErrorMessage);

        var category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);
        if (category == null)
            return CategoryErrors.NotFound(request.CategoryId);

        category.ChangeName(request.Name);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return (CategoryResponse)category;
    }
}