using System.Text.Json.Serialization;

namespace Application.Core.Responses;

public class AuthModelResponse
{
    public bool IsAuthenticated { get; set; }
    public Guid UserId { get; set; }
    public string Email { get; set; } = null!;
	public string UserName { get; set; } = null!;

	public List<string>? Roles { get; set; }

	public string Token { get; set; } = string.Empty;

}
