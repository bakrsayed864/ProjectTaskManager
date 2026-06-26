namespace Application.DTOs.AccountDTOs;

public class LoginUserDTO
{
    [Required] 
    public string UserName { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
