using Evently.Common.Domain.ResultPattern;
using MediatR;

namespace Evently.Common.Application.Messaging;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;


// Handlers
public interface ICommandHandler<TCommand> 
    : IRequestHandler<TCommand, Result> where TCommand : ICommand;

public interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse>;


