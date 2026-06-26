
using Application.Contracts.Services;
using Domain.Entities;

namespace Infrastructure.Services;

public class AccountService(UserManager<ApplicationUser> userManager,
	SignInManager<ApplicationUser> signInManager,
	IMapper mapper,
	ITokenService tokenService) : IAccountService
{

	private readonly UserManager<ApplicationUser> _userManager = userManager;
	private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
	private readonly IMapper _mapper = mapper;
	private readonly ITokenService _tokenService = tokenService;

	public async Task<Result<AuthModelResponse>> LoginAsync(LoginUserDTO loginUserDto)
	{
		var authModel = new AuthModelResponse();
		ApplicationUser? user;

		//get user if exist
		user = await _userManager.FindByNameAsync(loginUserDto.UserName!);
		if (user is null)
		{
			user = await _userManager.FindByEmailAsync(loginUserDto.UserName!);
			if (user is null)
				return Result.Failure<AuthModelResponse>(Error.InvalidOperation("User name or Email not exist"));
		}

		var checkPassword = await _signInManager.PasswordSignInAsync(user, loginUserDto.Password!, false, true);
		//bool checkPassword = await _userManager.CheckPasswordAsync(user, loginUserDto.Password!);

		if (!checkPassword.Succeeded)
			return Result.Failure<AuthModelResponse>(Error.InvalidOperation("Uncorrect Password"));

		else if (checkPassword.IsLockedOut)
			return Result.Failure<AuthModelResponse>(Error.InvalidOperation("User account locked out. Try again later."));

		//generate token..
		var tokenObj = await _tokenService.CreateTokenAsync(user);

        await PopulateAuthModelResponse(authModel, user, tokenObj);

        return Result.Success(authModel);

	}

	public async Task<Result<UserToReturnDTO>> RegisterAsync(RegisterUserDTO registerUserDto)
	{
		var user = _mapper.Map<ApplicationUser>(registerUserDto);

		try
		{
			var result = await _userManager.CreateAsync(user, registerUserDto.Password!);

			if (!result.Succeeded)
			{
				return Result.Failure<UserToReturnDTO>(
					Error.InvalidOperation(
						string.Join(", ",
							result.Errors.Select(x => x.Description))));
			}

			var userToReturnDTO =
				_mapper.Map<UserToReturnDTO>(user);

			return Result.Success(userToReturnDTO);
		}
		catch (Exception ex)
		{

			return Result.Failure<UserToReturnDTO>(
				Error.InvalidOperation(ex.Message));
		}
	}

	
	//*************************************************************************************
	//********************************** private methods **********************************
	//*************************************************************************************

	private async Task PopulateAuthModelResponse(AuthModelResponse authModel, ApplicationUser user, JwtSecurityToken newJwtToken)
	{
		authModel.IsAuthenticated = true;
		authModel.Email = user.Email ?? "no email";
		authModel.UserId = user.Id;
		authModel.UserName = user.UserName ?? "no userName";
		authModel.Token = new JwtSecurityTokenHandler().WriteToken(newJwtToken);
		authModel.Roles = [.. (await _userManager.GetRolesAsync(user))];
	}

}
