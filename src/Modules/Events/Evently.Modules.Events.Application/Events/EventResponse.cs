namespace Evently.Modules.Events.Application.Events;

public sealed record EventResponse(
    Guid Id,
    Guid CategoryId,
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc,
    string Status)
{
    public static explicit operator EventResponse(Event @event) =>
        new(
            @event.Id,
            @event.CategoryId,
            @event.Title,
            @event.Description,
            @event.Location,
            @event.StartsAtUtc,
            @event.EndsAtUtc,
            @event.Status.ToString());
}
