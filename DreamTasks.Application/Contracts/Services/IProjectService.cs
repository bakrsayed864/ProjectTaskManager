using Application.DTOs.ProjectDTOs;

namespace Application.Contracts.Services;

public interface IProjectService 
{
    Task<Result> CreateAsync(ProjectToCreateDTO dto);

    Task<Result> UpdateAsync(Guid Id, ProjectToUpdateDTO dto);

    Task<Result> DeleteAsync(Guid id);

    Task<Result<PaginatedResponse<ProjectToReturnDTO>>> GetAllAsync(int pageNumber, int pageSize);

    Task<Result<ProjectToReturnDTO>> GetByIdAsync(Guid id);

}

