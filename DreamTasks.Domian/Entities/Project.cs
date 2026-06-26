using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Project : IAuditableEntity
{
	public Guid Id { get; set; }

	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;


	public DateTime CreatedAt { get; set; }

	public IEnumerable<ProjectTask> ProjectTasks { get; set; } = [];

}
