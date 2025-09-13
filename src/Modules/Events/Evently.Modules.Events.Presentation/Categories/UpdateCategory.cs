using Evently.Modules.Events.Application.Categories.UpdateCategory;

namespace Evently.Modules.Events.Presentation.Categories;

public class UpdateCategory : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{categoryId}", async (Guid categoryId, UpdateCategoryRequest request, ISender sender) =>
        {
            var command = new UpdateCategoryCommand(categoryId, request.Name);
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        })
        .WithName(CategoryEndpointMetadata.UpdateCategory)
        .WithTags(CategoryEndpointMetadata.Tag);
    }

    public sealed record UpdateCategoryRequest(string Name);
}