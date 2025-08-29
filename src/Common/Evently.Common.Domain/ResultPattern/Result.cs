using Evently.Common.Domain.Erros;
using System.Diagnostics.CodeAnalysis;

namespace Evently.Common.Domain.ResultPattern;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = isSuccess;
        Error = error;
    }
    public static Result Success() => new(true, Error.None);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

    public static implicit operator Result(Error error) =>  Failure(error);
}

public class Result<T>(T? value, bool isSuccess, Error error) : Result(isSuccess, error)
{
    [NotNull]
    public T Value => IsSuccess
        ? value!
        : throw new InvalidOperationException("The value of a failure result can't be accessed.");
 
    public static implicit operator T([NotNull] Result<T> result) => result.Value;

    public static implicit operator Result<T>(T? value) => value is not null ? Success(value) : Failure<T>(Error.NullValue);

    public static implicit operator Result<T>(Error error) => Failure<T>(error);
 
}

// public static implicit/explicit operator TargetType(SourceType source) { conversion logic here }
// https://medium.com/@gustavorestani/c-implicit-and-explicit-operators-a-comprehensive-guide-5e6972cc8671