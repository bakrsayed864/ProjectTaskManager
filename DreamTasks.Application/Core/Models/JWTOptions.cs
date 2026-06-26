namespace Application.Core.Models;

public class JWTOptions
{
    public static string SectionName = "JWT";
    [Required] public required string Key { get; set; }
    [Required] public required string Issuer { get; set; }
    [Required] public required string Audience { get; set; }
    [Range(5, 500)] public int ExpiryMinutes { get; set; }
}
