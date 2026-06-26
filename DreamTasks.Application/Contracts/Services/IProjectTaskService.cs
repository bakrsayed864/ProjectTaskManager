using Application.DTOs.ProjectTasksDTOs;

namespace Application.Contracts.Services;

public interface IProjectTaskService 
{
    Task<Result<ProjectTaskToReturnDTO>> CreateAsync(ProjectTaskToCreateDTO dto);

    Task<Result<ProjectTaskToReturnDTO>> UpdateStatusAsync(Guid Id, UpdateProjectTaskStatusDTO dto);

    Task<Result<IReadOnlyList<ProjectTaskToReturnDTO>>> GetByProject(Guid projectId);

    Task<Result> DeleteASync(Guid Id);
}
