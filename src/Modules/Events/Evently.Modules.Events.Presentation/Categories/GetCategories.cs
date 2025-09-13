using Evently.Modules.Events.Application.Categories.GetCategories;

namespace Evently.Modules.Events.Presentation.Categories;

public class GetCategories : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("categories", async (ISender sender) =>
        {
            var result = await sender.Send(new GetCategoriesQuery());
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        })
        .WithName(CategoryEndpointMetadata.GetCategories)
        .WithTags(CategoryEndpointMetadata.Tag);
    }
}