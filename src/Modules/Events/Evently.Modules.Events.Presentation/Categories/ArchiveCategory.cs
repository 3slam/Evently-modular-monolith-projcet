using Evently.Modules.Events.Application.Categories.ArchiveCategory;

namespace Evently.Modules.Events.Presentation.Categories;

public class ArchiveCategory : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPatch("categories/{categoryId}/archive", async (Guid categoryId, ISender sender) =>
        {
            var result = await sender.Send(new ArchiveCategoryCommand(categoryId));
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        })
        .WithName(CategoryEndpointMetadata.ArchiveCategory)
        .WithTags(CategoryEndpointMetadata.Tag);
    }
}