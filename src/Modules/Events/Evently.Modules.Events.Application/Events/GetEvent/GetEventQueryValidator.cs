using Evently.Modules.Events.Application.Events.GetEvent;

namespace Evently.Modules.Events.Application.Events.CancelEvent;

public sealed class GetEventQueryValidator : AbstractValidator<GetEventQuery>
{
   public GetEventQueryValidator()
   {
        RuleFor(x => x.EventId).NotEmpty();
   }
    
}