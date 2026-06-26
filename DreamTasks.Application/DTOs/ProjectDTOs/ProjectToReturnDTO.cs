using Domain.Enums;

namespace Application.DTOs.ProjectDTOs;

public class ProjectToReturnDTO : IAudiatableDTO, IBaseDTO
{

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public Guid Id { get; set; }
}
