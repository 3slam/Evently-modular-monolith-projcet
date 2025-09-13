namespace Evently.Modules.Events.Application.TicketTypes.GetTicketType;

public sealed class GetTicketTypeQueryValidator : AbstractValidator<GetTicketTypeQuery>
{
    public GetTicketTypeQueryValidator()
    {
        RuleFor(c => c.TicketTypeId).NotEmpty();
    }
}