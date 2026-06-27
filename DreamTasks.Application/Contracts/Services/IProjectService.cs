using Application.DTOs.ProjectDTOs;

namespace Application.Contracts.Services;

public interface IProjectService 
{
    Task<Result<ProjectToReturnDTO>> CreateAsync(ProjectToCreateDTO dto);

    Task<Result<ProjectToReturnDTO>> UpdateAsync(Guid Id, ProjectToUpdateDTO dto);

    Task<Result> DeleteAsync(Guid id);

    Task<Result<PaginatedResponse<ProjectToReturnDTO>>> GetAllAsync(int pageNumber, int pageSize);

    Task<Result<ProjectToReturnDTO>> GetByIdAsync(Guid id);

}

