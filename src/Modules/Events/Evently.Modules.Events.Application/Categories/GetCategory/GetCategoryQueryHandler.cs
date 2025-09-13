namespace Evently.Modules.Events.Application.Categories.GetCategory;

public sealed class GetCategoryQueryHandler(
    ICategoryRepository categoryRepository,
    IValidator<GetCategoryQuery> validator): IRequestHandler<GetCategoryQuery, Result<CategoryResponse>>
{
    public async Task<Result<CategoryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return CategoryErrors.Validation(validationResult.Errors.FirstOrDefault()?.ErrorMessage);

        var category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);
        if (category == null)
            CategoryErrors.NotFound(request.CategoryId);

        return (CategoryResponse)category!;
    }
}