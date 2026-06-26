using Domain.Entities;

namespace Infrastructure.Data.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
	public void Configure(EntityTypeBuilder<Project> builder)
	{
		builder.HasMany(p => p.ProjectTasks)
			.WithOne(t => t.Project)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
