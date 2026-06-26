using Application.DTOs.AccountDTOs;

namespace Application.Contracts.Services;

public interface IAccountService
{
	Task<Result<UserToReturnDTO>> RegisterAsync(RegisterUserDTO registerUserDTO);

    Task<Result<AuthModelResponse>> LoginAsync(LoginUserDTO loginUserDTO);

}
