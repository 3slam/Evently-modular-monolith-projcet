namespace Evently.Modules.Events.Application.Categories.ArchiveCategory;

public sealed class ArchiveCategoryCommandHandler(
    IUnitOfWork unitOfWork,
    ICategoryRepository categoryRepository,
    IValidator<ArchiveCategoryCommand> validator): IRequestHandler<ArchiveCategoryCommand, Result<CategoryResponse>>
{
    public async Task<Result<CategoryResponse>> Handle(ArchiveCategoryCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return CategoryErrors.Validation(validationResult.Errors.FirstOrDefault()?.ErrorMessage);

        var category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);

        if (category == null)
            return CategoryErrors.NotFound(request.CategoryId);

        category.Archive();
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return (CategoryResponse)category;
    }
}