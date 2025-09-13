using Evently.Modules.Events.Application.Categories.GetCategory;

namespace Evently.Modules.Events.Presentation.Categories;

internal class GetCategory : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("categories/{categoryId}", async (Guid categoryId, ISender sender) =>
        {
            var result = await sender.Send(new GetCategoryQuery(categoryId));
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        })
        .WithTags(CategoryEndpointMetadata.Tag)
        .WithName(CategoryEndpointMetadata.GetCategory);
    }
}