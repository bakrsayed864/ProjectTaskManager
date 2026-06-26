using Application.Contracts.Services;
using Application.DTOs.ProjectDTOs;
using Application.DTOs.ProjectTasksDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProjectTasksController(IProjectTaskService projectTaskService) : BaseApiController
{
    private readonly IProjectTaskService _projectTaskService = projectTaskService;

    [HttpPost("Create")]
    public async Task<ActionResult> Create(ProjectTaskToCreateDTO dto)
    {
        var result = await _projectTaskService.CreateAsync(dto);

        return HandleResult(result);
    }


    [HttpPut("UpdateStatus/{Id:guid}")]
    public async Task<ActionResult> UpdateStatus([FromRoute] Guid Id, UpdateProjectTaskStatusDTO dto)
    {
        var result = await _projectTaskService.UpdateStatusAsync(Id, dto);

        return HandleResult(result);
    }

    [HttpGet("GetByProjectId/{projectId}")]
    public async Task<ActionResult<List<ProjectToReturnDTO>>> GetByProjectId([FromRoute] Guid projectId)
    {
        var result = await _projectTaskService.GetByProject(projectId);

        return HandleResult(result);
    }



    [HttpDelete("Delete/{Id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid Id)
    {
        var result = await _projectTaskService.DeleteASync(Id);

        return HandleResult(result);
    }
}
