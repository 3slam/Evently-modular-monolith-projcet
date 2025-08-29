using Evently.Common.Domain.BaseEntity;
using Evently.Common.Domain.ResultPattern;
using Evently.Modules.Events.Domain.Events.DomainEvents;

namespace Evently.Modules.Events.Domain.Events.Models;

public sealed class Event : Entity
{
    public Guid Id { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Location { get; private set; } = string.Empty;
    public DateTime StartsAtUtc { get; private set; }
    public DateTime? EndsAtUtc { get; private set; }
    public EventStatus Status { get; private set; }

    public static Result<Event> CreateDraft(
       Guid categoryId,
       string title,
       string description,
       string location,
       DateTime startsAtUtc,
       DateTime? endsAtUtc)
    {
        if (endsAtUtc.HasValue && endsAtUtc < startsAtUtc)
            return EventErrors.EndDatePrecedesStartDate;

        var @event = new Event
        {
            Id = Guid.NewGuid(),
            CategoryId = categoryId,
            Title = title,
            Description = description,
            Location = location,
            StartsAtUtc = startsAtUtc,
            EndsAtUtc = endsAtUtc,
            Status = EventStatus.Draft
        };

        @event.RaiseDomainEvent(new EventCreatedDomainEvent()
        { 
            EventId = @event.Id 
        });

        return @event;
    }

    public Result Publish()
    {
        if (Status != EventStatus.Draft)
            return EventErrors.NotDraft; // it will convert to Error type to Failure Result using implicit operator inside Result class

        Status = EventStatus.Published;

        RaiseDomainEvent(new EventPublishedDomainEvent() { EventId = Id});

        return Result.Success();
    }

    public Result Reschedule(DateTime startsAtUtc, DateTime? endsAtUtc)
    {
        if (endsAtUtc < startsAtUtc)
            return EventErrors.EndDatePrecedesStartDate;

        StartsAtUtc = startsAtUtc;
        EndsAtUtc = endsAtUtc;

        RaiseDomainEvent(new EventRescheduledDomainEvent() 
        { 
            EndsAtUtc = EndsAtUtc,
            StartsAtUtc = StartsAtUtc ,
            EventId = Id
        });

        return Result.Success();
    }

    public Result Cancel(DateTime utcNow)
    {
        if (Status == EventStatus.Cancelled)
            return EventErrors.AlreadyCancelled;

        if (StartsAtUtc < utcNow)
            return EventErrors.AlreadyStarted;

        Status = EventStatus.Cancelled;

        RaiseDomainEvent(new EventCancelledDomainEvent() 
        { 
            EventId = Id 
        });

        return Result.Success();
    }

}
