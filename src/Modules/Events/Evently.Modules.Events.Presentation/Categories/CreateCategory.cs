using Evently.Modules.Events.Application.Categories.CreateCategory;

namespace Evently.Modules.Events.Presentation.Categories;

internal sealed class CreateCategory : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("categories", async (CreateCategoryRequest request, ISender sender) =>
        {
            var command = new CreateCategoryCommand(request.Name);
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        })
        .WithName(CategoryEndpointMetadata.CreateCategory)
        .WithTags(CategoryEndpointMetadata.Tag);
    }

    internal sealed record CreateCategoryRequest(string Name);
}