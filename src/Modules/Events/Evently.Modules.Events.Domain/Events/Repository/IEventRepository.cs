using Evently.Modules.Events.Domain.Events.Models;

namespace Evently.Modules.Events.Domain.Events.Repository;

public interface IEventRepository
{
    Task<Event?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Event @event, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Event>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Event>> SearchAsync(string? title, DateTime? startsAtUtc, CancellationToken cancellationToken = default);
}
