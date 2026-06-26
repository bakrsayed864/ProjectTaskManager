namespace Application.DTOs.AccountDTOs;

public class RegisterUserDTO : LoginUserDTO
{
    [Required]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = null!;

    [Required, EmailAddress]
    public string? Email { get; set; }

    [Required]
    [RegularExpression(@"^01[0125]\d{8}$", ErrorMessage = "Please enter a valid Egyptian mobile number.")]
    public string PhoneNumber { get; set; } = null!;
}
