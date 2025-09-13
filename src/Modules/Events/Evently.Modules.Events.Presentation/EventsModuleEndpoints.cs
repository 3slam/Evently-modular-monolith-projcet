using Evently.Modules.Events.Presentation.Categories;
using Evently.Modules.Events.Presentation.TicketTypes;

namespace Evently.Modules.Events.Presentation;

public static class EventsModuleEndpoints
{
    public static void Map(this IEndpointRouteBuilder app)
    {
        MapEventEndpoints(app);
        MapCategoryEndpoints(app);
        MapTicketTypeEndpoints(app);
    }

    private static void MapEventEndpoints(IEndpointRouteBuilder app)
    {
        new GetEvents().Map(app);
        new GetEvent().Map(app);
        new CreateEvent().Map(app);
        new RescheduleEvent().Map(app);
        new PublishEvent().Map(app);
        new SearchEvents().Map(app);
    }

    private static void MapCategoryEndpoints(IEndpointRouteBuilder app)
    {
        new GetCategories().Map(app);
        new GetCategory().Map(app);
        new CreateCategory().Map(app);
        new UpdateCategory().Map(app);
        new ArchiveCategory().Map(app);
    }

    private static void MapTicketTypeEndpoints(IEndpointRouteBuilder app)
    {
        new GetTicketTypes().Map(app);
        new GetTicketType().Map(app);
        new CreateTicketType().Map(app);
        new UpdateTicketTypePrice().Map(app);
    }
}
