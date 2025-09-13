namespace Evently.Modules.Events.Application.Events.CancelEvent;

internal sealed class GetEventQueryValidator : AbstractValidator<CancelEventCommand>
{
   public GetEventQueryValidator() => RuleFor(x => x.EventId).NotEmpty();
    
}