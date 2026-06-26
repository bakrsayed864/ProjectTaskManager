namespace Application.DTOs.AccountDTOs;

public class UserToReturnDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
