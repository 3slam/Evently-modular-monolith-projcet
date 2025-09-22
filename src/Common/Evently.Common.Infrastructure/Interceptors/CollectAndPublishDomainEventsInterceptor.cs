using Evently.Common.Domain.BaseEntity;
using Evently.Common.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Common.Infrastructure.Interceptors;

public sealed class CollectAndPublishDomainEventsInterceptor(
    IServiceScopeFactory serviceScopeFactory) : SaveChangesInterceptor
{

    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            await PublishDomainEventsAsync(eventData.Context, cancellationToken);
        }
        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }
     

    private async Task PublishDomainEventsAsync(DbContext context, CancellationToken cancellationToken)
    {
        var domainEvents = context
             .ChangeTracker
             .Entries<Entity>()
             .Select(e => e.Entity)
             .SelectMany(entity =>
             {
                 IReadOnlyCollection<IDomainEvent> events = entity.GetDomainEvents();
                 entity.ClearDomainEvents();
                 return events;
             })
             .ToList();  

        if (domainEvents.Count == 0)
            return;

        using IServiceScope scope = serviceScopeFactory.CreateScope();
        var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

        foreach (IDomainEvent domainEvent in domainEvents)
        {
            await publisher.Publish(domainEvent, cancellationToken);
        }
    }
}
