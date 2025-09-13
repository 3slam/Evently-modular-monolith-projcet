namespace Evently.Modules.Events.Application.Events.SearchEvents;

public sealed record SearchEventsQuery(string? Title, DateTime? StartsAtUtc) : IRequest<Result<IReadOnlyCollection<EventResponse>>>;
