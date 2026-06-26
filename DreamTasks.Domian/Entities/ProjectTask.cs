using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(ProjectId), nameof(Title), IsUnique = true)]
public class ProjectTask : IBaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime DueDate { get; set; } 

    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }

    public Guid Id { get; set; }
}
