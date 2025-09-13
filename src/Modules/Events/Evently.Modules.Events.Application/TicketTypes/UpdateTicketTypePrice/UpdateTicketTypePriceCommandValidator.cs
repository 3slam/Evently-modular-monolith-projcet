namespace Evently.Modules.Events.Application.TicketTypes.UpdateTicketTypePrice;

public sealed class UpdateTicketTypePriceCommandValidator : AbstractValidator<UpdateTicketTypePriceCommand>
{
    public UpdateTicketTypePriceCommandValidator()
    {
        RuleFor(c => c.TicketTypeId).NotEmpty();
        RuleFor(c => c.Price).GreaterThanOrEqualTo(0);
    }
}