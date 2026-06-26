using Domain.Entities;

namespace Application.Contracts.Repositories;

public interface IProjectRepository
{
    Task<Project> CreateAsync(Project project);

    Task<IEnumerable<Project>> GetAllAsync(int pageNumber, int pageSize);

    Task<Project?> GetByIdAsync(Guid id); 

    Task UpdateAsync(Project project);

    Task DeleteAsync(Project project);

    Task<int> CountAsync();

}
