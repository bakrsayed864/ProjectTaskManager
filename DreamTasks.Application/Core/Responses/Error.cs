
namespace Application.Core.Responses;

public sealed record Error(string Message)
{
	public static Error NotFound(string resource = "Resource")
		=> new($"{resource} was not found.");

	public static Error AlreadyExists(string resource = "Resource")
		=> new($"{resource} already exists.");

	public static Error InvalidInput(string? message = null)
		=> new(message ?? "Invalid input.");

	public static Error InvalidOperation(string? message = null)
		=> new(message ?? "Invalid Operation.");

	public static Error Validation(string? message = null)
		=> new(message ?? "Validation failed.");

	public static Error Unauthorized(string? message = null)
		=> new(message ?? "Unauthorized.");

}
