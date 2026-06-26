namespace Application.Core.Models;

public class MailSettings
{
	public string? Email { get; set; }
	public string? DisplayName { get; set; }
	public string? Password { get; set; }
	public string? Host { get; set; }
	public int Port { get; set; }

	public string? ContactUsEmail { get; set; }
	public string? SupportEmail { get; set; }
	public string? AppName { get; set; }
	public string? AppBaseUrl { get; set; }
}
