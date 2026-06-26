using Application.Contracts.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class ProjectRepository(ApplicationDbContext context) : IProjectRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Project> CreateAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();

        return project; 
    }

    public async Task DeleteAsync(Project project)
    {
        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Project>> GetAllAsync(int pageNumber, int pageSize)
    {
        var list = await _context.Projects
            .Skip((pageNumber-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();

       
        return list;
    }
     
    public async Task<Project?> GetByIdAsync(Guid id)
    { 
        var project = await _context.Projects
            .FindAsync(id);

        return project;
    }

    public async Task UpdateAsync(Project project)
    {
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
      => await _context.Projects.CountAsync();

}
