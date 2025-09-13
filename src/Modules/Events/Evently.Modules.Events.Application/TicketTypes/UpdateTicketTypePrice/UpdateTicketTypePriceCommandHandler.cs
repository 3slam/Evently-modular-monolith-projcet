namespace Evently.Modules.Events.Application.TicketTypes.UpdateTicketTypePrice;

public sealed class UpdateTicketTypePriceCommandHandler(
    IUnitOfWork unitOfWork,
    ITicketTypeRepository ticketTypeRepository,
    IValidator<UpdateTicketTypePriceCommand> validator) : IRequestHandler<UpdateTicketTypePriceCommand, Result<TicketTypeResponse>>
{
    public async Task<Result<TicketTypeResponse>> Handle(UpdateTicketTypePriceCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return TicketTypeErrors.Validation(validationResult.Errors.FirstOrDefault()?.ErrorMessage);

        var ticketType = await ticketTypeRepository.GetAsync(request.TicketTypeId, cancellationToken);

        if (ticketType is null)
           return TicketTypeErrors.NotFound(request.TicketTypeId);

        ticketType.UpdatePrice(request.Price);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return (TicketTypeResponse)ticketType;
    }
}