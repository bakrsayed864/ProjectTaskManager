using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.DTOs.ProjectDTOs;
using Domain.Entities;

namespace Application.Services;

public class ProjectService(IProjectRepository projectRepository,
    IMapper mapper) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Result> CreateAsync(ProjectToCreateDTO dto)
    {
        //map to entity
        var project = _mapper.Map<Project>(dto);

        //try to save in database
        try
        {
            await _projectRepository.CreateAsync(project);
        }catch(Exception ex)
        {
            return Result.Failure(Error.InvalidOperation($"An error occured while saving project in database, Exception: {ex.Message}"));
        }

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(Guid id)
    {
        // get project
        var project = await _projectRepository.GetByIdAsync(id);

        if (project is null)
            return Result.Failure(Error.NotFound("Project"));

        try
        {
            await _projectRepository.DeleteAsync(project);
        }catch(Exception ex)
        {
            return Result.Failure(Error.InvalidOperation($"An error occurred while deleting this project, Exception: {ex.Message}"));
        }

        return Result.Success();
    }


    public async Task<Result<PaginatedResponse<ProjectToReturnDTO>>> GetAllAsync(int pageNumber, int pageSize)
    {
        var projects = await _projectRepository.GetAllAsync(pageNumber, pageSize);

        //map to project to return dto
        var dtos = _mapper.Map<List<ProjectToReturnDTO>>(projects);
        var totalCount = await _projectRepository.CountAsync();

        var paginatedResponse = new PaginatedResponse<ProjectToReturnDTO>(dtos, totalCount, pageNumber, pageSize);

        return Result.Success(paginatedResponse);
    }

    public async Task<Result<ProjectToReturnDTO>> GetByIdAsync(Guid id)
    {
        var project = await _projectRepository.GetByIdAsync(id);

        if (project is null)
            return Result.Failure<ProjectToReturnDTO>(Error.NotFound("project"));

        var dto = _mapper.Map<ProjectToReturnDTO>(project);

        return Result.Success(dto);
    }


    public async Task<Result> UpdateAsync(Guid id, ProjectToUpdateDTO dto)
    {
        //get project 
        var projectToUpdate = await _projectRepository.GetByIdAsync(id);

        if (projectToUpdate is null)
            return Result.Failure(Error.NotFound("Project"));

        //map dto to project
        dto.Adapt(projectToUpdate);

        try
        {
            await _projectRepository.UpdateAsync(projectToUpdate);
        }
        catch(Exception ex)
        {
            return Result.Failure(Error.InvalidOperation($"Ann error occurred while updating project, Exception:{ex.Message}"));
        }

        return Result.Success();
    }
}
