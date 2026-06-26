using Application.Contracts.Services;
using Application.DTOs.ProjectDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController(IProjectService projectService) : BaseApiController
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost("Create")]
    public async Task<ActionResult> Create(ProjectToCreateDTO dto)
    {
        var result = await _projectService.CreateAsync(dto);

        return HandleResult(result);
    }


    [HttpPut("Update/{Id:guid}")]
    public async Task<ActionResult> Update([FromRoute] Guid Id, ProjectToUpdateDTO dto)
    {
        var result = await _projectService.UpdateAsync(Id, dto);

        return HandleResult(result);
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<ProjectToReturnDTO>>> GetAll([FromQuery] int? pageNumber = null,[FromQuery] int? pageSize = null)
    {
        var result = await _projectService.GetAllAsync(pageNumber ?? 1, pageSize ?? 10);

        return HandleResult(result);
    }

    [HttpGet("GetById/{Id:guid}")]
    public async Task<ActionResult<ProjectToReturnDTO>> GetById([FromRoute] Guid Id)
    {
        var result = await _projectService.GetByIdAsync(Id);

        return HandleResult(result);
    }

    [HttpDelete("Delete/{Id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid Id)
    {
        var result = await _projectService.DeleteAsync(Id);

        return HandleResult(result);
    }
}
