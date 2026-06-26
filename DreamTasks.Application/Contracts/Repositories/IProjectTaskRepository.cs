using Application.DTOs.ProjectTasksDTOs;
using Domain.Entities;
using Domain.Enums;

namespace Application.Contracts.Repositories;

public interface IProjectTaskRepository
{
    Task<ProjectTask?> GetById(Guid id);

    Task<ProjectTask> CreateAsync(ProjectTask projectTask);

    Task<ProjectTask?> UpdateStatus(Guid id, Status status);

    Task<IEnumerable<ProjectTask>> GetTasksByProject(Guid projectId);

    Task DeleteAsync(ProjectTask projectTask);

}
