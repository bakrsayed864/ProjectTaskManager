using Domain.Enums;

namespace Application.DTOs.ProjectTasksDTOs;

public class ProjectTaskToReturnDTO : IAudiatableDTO, IBaseDTO
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime DueDate { get; set; }

    public Guid ProjectId { get; set; }
    public string ProjectName { get; set; } = null!;
     
    public DateTime CreatedAt { get ; set ; }
    public Guid Id { get ; set ; }
}
