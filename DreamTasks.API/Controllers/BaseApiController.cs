using Application.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public  class BaseApiController : ControllerBase
{
    protected ActionResult HandleResult(Result result, int SuccessStatusCode=200, int FailureStatusCode=400)
    {
        if (result.IsFailure)
            return StatusCode(FailureStatusCode, result.Error);

        return StatusCode(SuccessStatusCode, result);
    }
}
