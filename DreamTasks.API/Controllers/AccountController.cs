using Application.Contracts.Services;
using Application.Core.Responses;
using Application.DTOs.AccountDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IAccountService accountService) : BaseApiController
{
    private readonly IAccountService _accountService = accountService;

    [HttpPost(nameof(Register))]
    public async Task<ActionResult> Register([FromBody] RegisterUserDTO registerUserDto)
    {
        var response = await _accountService.RegisterAsync(registerUserDto);
        return HandleResult(response);
    }


    [HttpPost(nameof(Login))]
    public async Task<ActionResult<AuthModelResponse>> Login(LoginUserDTO loginUserDto)
    {
        var result = await _accountService.LoginAsync(loginUserDto);

		return HandleResult(result);
    }

}
