namespace Evently.Modules.Events.Application.Events.CancelEvent;

public sealed class CancelEventCommandValidator : AbstractValidator<CancelEventCommand>
{
   public CancelEventCommandValidator()
   {
        RuleFor(x => x.EventId).NotEmpty();
   }
}