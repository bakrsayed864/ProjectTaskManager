using Application.Contracts.Repositories;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Repositories;

public class ProjectTaskRepository(ApplicationDbContext context) : IProjectTaskRepository
{
    private readonly ApplicationDbContext _context = context; 


    public async Task<ProjectTask> CreateAsync(ProjectTask projectTask)
    {
        await _context.ProjectTasks.AddAsync(projectTask);

        await _context.SaveChangesAsync();

        return projectTask;
    }

    public async Task DeleteAsync(ProjectTask projectTask)
    {
        _context.ProjectTasks.Remove(projectTask);

        await _context.SaveChangesAsync();
    }

    public async Task<ProjectTask?> GetById(Guid id)
        => await _context.ProjectTasks.FindAsync(id);

    public async Task<IEnumerable<ProjectTask>> GetTasksByProject(Guid projectId)
        => await _context.ProjectTasks.Where(task => task.ProjectId == projectId).ToListAsync();

    public async Task<bool> IsExist(string title, Guid projectId, Guid? Id = null)
        => Id == null ?
        await _context.ProjectTasks.AnyAsync(x => x.Title == title && x.ProjectId == projectId) :
        await _context.ProjectTasks.AnyAsync(x => (x.Title == title && x.ProjectId == projectId) && x.Id != Id);


    public async Task<ProjectTask?> UpdateStatus(Guid id, Status status)
    {
        var task = await _context.ProjectTasks.FindAsync(id);

        if(task is null)
            return null;

        task.Status = status;

        await _context.SaveChangesAsync();

        return task;
    }
}
