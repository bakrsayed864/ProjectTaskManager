using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.DTOs.ProjectTasksDTOs;
using Domain.Entities;

namespace Application.Services;

public class ProjectTaskService(IProjectTaskRepository projectTaskRepository, IMapper mapper) : IProjectTaskService
{
    private readonly IProjectTaskRepository _projectTaskRepository = projectTaskRepository;
    private readonly IMapper _mapper = mapper;
     
    public async Task<Result<ProjectTaskToReturnDTO>> CreateAsync(ProjectTaskToCreateDTO dto)
    {
        //check task title is existance within same project
        var isExist = await _projectTaskRepository.IsExist(dto.Title, dto.ProjectId);
        if (isExist)
            return Result.Failure<ProjectTaskToReturnDTO>(Error.Conflict("Same task title is exist for this project before"));

        //map dto to model
        var projectTask = _mapper.Map<ProjectTask>(dto);

        try
        {
           await _projectTaskRepository.CreateAsync(projectTask);
        }
        catch(Exception ex)
        {
            return Result.Failure<ProjectTaskToReturnDTO>(Error.InvalidOperation($"An error occured while creating Project Task, {ex.Message}"));
        }

        return Result.Success(_mapper.Map<ProjectTaskToReturnDTO>(projectTask));
    }

    public async Task<Result> DeleteASync(Guid Id)
    {
        var task = await _projectTaskRepository.GetById(Id);

        if (task is null)
            return Result.Failure(Error.NotFound("Project Task"));

        try
        {
            await _projectTaskRepository.DeleteAsync(task);
        }catch(Exception ex)
        {
            return Result.Failure(Error.InvalidOperation($"An error occurred while deleting task, Exception: {ex.Message}"));
        }

        return Result.Success(task);
    }

    public async Task<Result<IReadOnlyList<ProjectTaskToReturnDTO>>> GetByProject(Guid projectId)
    {
        var tasks = await _projectTaskRepository.GetTasksByProject(projectId);

        var dtos = _mapper.Map<IReadOnlyList<ProjectTaskToReturnDTO>>(tasks);

        return Result.Success(dtos);
    }

    public async Task<Result<ProjectTaskToReturnDTO>> UpdateStatusAsync(Guid Id, UpdateProjectTaskStatusDTO dto)
    {
        var task = await _projectTaskRepository.UpdateStatus(Id, dto.Status);

        if (task is null)
            return Result.Failure<ProjectTaskToReturnDTO>(Error.NotFound("Project Task"));

        return Result.Success(_mapper.Map<ProjectTaskToReturnDTO>(task));
    }
}
