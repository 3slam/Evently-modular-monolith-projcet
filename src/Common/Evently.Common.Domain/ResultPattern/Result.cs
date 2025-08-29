using Evently.Common.Domain.Erros;

namespace Evently.Common.Domain.ResultPattern;

public record Result
{
    public bool IsSuccess { get; private set; }
    public Error Error { get; private set; }
    public bool IsFailure => !IsSuccess;
 
    public Result(bool isSuccess, Error error)
    { 
       if ( isSuccess && error != Error.None || !isSuccess && error == Error.None)
            throw new InvalidOperationException("The result is not valid");

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);
    public static Result<T> Success<T>(T value) => new (value, true, Error.None);
    public static Result<T> Failure<T>(Error error) => new (default,false, error);
    public static Result Failure(Error error) => new(false, error);

    public static implicit operator Result(Error error) => Failure(error);
}

public sealed record Result<T>(T? value, bool isSuccess, Error error) : Result(isSuccess, error)
{
    public T Value => IsSuccess ? value! : throw new InvalidOperationException("The result is not valid");

    public static implicit operator T(Result<T> result) => result.Value;

    public static implicit operator Result<T>(T? value) => value is not null ? Success(value) : Failure<T>(Error.NullValue);

    public static implicit operator Result<T>(Error error) => Failure<T>(error);

}

// public static implicit/explicit operator TargetType(SourceType source) { conversion logic here }
// https://medium.com/@gustavorestani/c-implicit-and-explicit-operators-a-comprehensive-guide-5e6972cc8671