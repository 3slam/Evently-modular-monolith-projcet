namespace Evently.Modules.Events.Application.Categories.GetCategories;

public sealed class GetCategoriesQuery : IRequest<Result<IReadOnlyCollection<CategoryResponse>>> { }