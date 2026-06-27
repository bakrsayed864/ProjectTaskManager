using Application.Enums;

namespace Application.Core.Responses;

public sealed record Error(ErrorCode Code, string Message)
{
	public static readonly Error None = new(ErrorCode.None, string.Empty);

	public static Error Default(string? message = null)
		=> new(ErrorCode.BadRequest, message ?? "An error occurred.");

	public static Error NotFound(string resource = "Resource")
		=> new(ErrorCode.NotFound, $"{resource} was not found.");

	public static Error AlreadyExists(string resource = "Resource")
		=> new(ErrorCode.AlreadyExists, $"{resource} already exists.");

	public static Error InvalidInput(string? message = null)
		=> new(ErrorCode.Validation, message ?? "Invalid input.");

	public static Error InvalidOperation(string? message = null)
		=> new(ErrorCode.Validation, message ?? "Invalid Operation.");

	public static Error Validation(string? message = null)
		=> new(ErrorCode.Validation, message ?? "Validation failed.");

	public static Error Unauthorized(string? message = null)
		=> new(ErrorCode.Unauthorized, message ?? "Unauthorized.");

	public static Error Forbidden(string? message = null)
		=> new(ErrorCode.Forbidden, message ?? "Forbidden.");

	public static Error Conflict(string? message = null)
		=> new(ErrorCode.Conflict, message ?? "Conflict occurred.");

	public static Error DatabaseError(string? message = null)
		=> new(ErrorCode.DatabaseError, message ?? "Database error occurred.");

}
