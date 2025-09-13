namespace Evently.Modules.Events.Presentation;

public static class EventsEndpoints
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        new GetEvents().Map(app);
        new GetEvent().Map(app);
        new CreateEvent().Map(app);
        new RescheduleEvent().Map(app);
        new PublishEvent().Map(app);
        new SearchEvents().Map(app);
    }
}
