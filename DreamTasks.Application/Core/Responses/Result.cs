namespace Application.Core.Responses;

public class Result
{

	public Result(bool isSuccess)
	{
		IsSuccess = isSuccess;
	}

	public bool IsSuccess { get; }
	public bool IsFailure => !IsSuccess;
	public Error Error { get; } = default!;

	public static Result Success() => new(true);
	public static Result Failure(Error error) => new(false);
	public static Result<TValue> Success<TValue>(TValue value) => new(value, true);
	public static Result<TValue> Failure<TValue>(Error error) => new(default, false);

}

public class Result<TValue>(TValue? value, bool isSuccess) : Result(isSuccess)
{
	private readonly TValue? _value = value;

	public TValue Value => IsSuccess
		? _value ?? throw new InvalidOperationException("Value is null.")
		: throw new InvalidOperationException("Cannot access value when result is a failure.");
}
