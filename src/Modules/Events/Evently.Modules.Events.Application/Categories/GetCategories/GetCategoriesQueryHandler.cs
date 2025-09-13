
namespace Evently.Modules.Events.Application.Categories.GetCategories;

public sealed class GetCategoriesQueryHandler(
    ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesQuery, Result<IReadOnlyCollection<CategoryResponse>>>
{
    public async Task<Result<IReadOnlyCollection<CategoryResponse>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllAsync(cancellationToken);
        var response = categories.Select(c => (CategoryResponse)c).ToList();
        return response;
    }
}