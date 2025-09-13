namespace Evently.Modules.Events.Application.TicketTypes.CreateTicketType;

public sealed class CreateTicketTypeCommandHandler(
    IUnitOfWork unitOfWork,
    ITicketTypeRepository ticketTypeRepository,
    IEventRepository eventRepository,
    IValidator<CreateTicketTypeCommand> validator) : IRequestHandler<CreateTicketTypeCommand, Result<TicketTypeResponse>>
{
    public async Task<Result<TicketTypeResponse>> Handle(CreateTicketTypeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return TicketTypeErrors.Validation(validationResult.Errors.FirstOrDefault()?.ErrorMessage);

        var @event = await eventRepository.GetAsync(request.EventId, cancellationToken);

        if (@event is null)
            return EventErrors.NotFound(request.EventId);

        var ticketType = TicketType.Create(
            @event,
            request.Name,
            request.Price,
            request.Currency,
            request.Quantity);

        ticketTypeRepository.Insert(ticketType);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return (TicketTypeResponse)ticketType;
    }
}