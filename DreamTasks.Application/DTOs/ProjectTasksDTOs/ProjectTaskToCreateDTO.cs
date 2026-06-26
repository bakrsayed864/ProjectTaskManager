using Domain.Enums;

namespace Application.DTOs.ProjectTasksDTOs;

public class ProjectTaskToCreateDTO
{
    [Required]
    [Length(5, 100, ErrorMessage = "Title should be grater than 5 and less than 100 character")]
    public string Title { get; set; } = null!;
    [Required]
    [Length(10, 200, ErrorMessage = "Description should be grater than 10 and less than 200 character")]
    public string Description { get; set; } = null!;

    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime DueDate { get; set; }

    public Guid ProjectId { get; set; }
}
