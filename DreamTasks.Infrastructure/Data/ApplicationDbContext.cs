using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor, ILogger<ApplicationDbContext> loggerFactory) : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid,
                        IdentityUserClaim<Guid>, IdentityUserRole<Guid>,
                        IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>,
                        IdentityUserToken<Guid>>(options)
{

    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly ILogger<ApplicationDbContext> _loggerFactory = loggerFactory;

    #region core models
    public DbSet<ApplicationUser> ApplicationUsers { get; set; } = default!;
	#endregion

	public DbSet<Project> Projects { get; set; } = default!;

	public DbSet<ProjectTask> ProjectTasks { get; set; } = default!; 

	protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Apply all configurations from the current assembly
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

	private void SaveAuditInfo()
	{
		// =========================
		// Audit Information Section
		// =========================

		// Get all entities implementing IAuditableEntity
		var auditEntries = ChangeTracker.Entries<IAuditableEntity>();

		// Current system time
		var now = TimeZoneHelper.GetCurrentDateTime();

		// Current authenticated user
		var user = _httpContextAccessor.HttpContext?.User;

		// Get user id from claims
		var userIdClaim =
			user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

		// Safely parse user id
		Guid? parsedUserId = null;

		if (!string.IsNullOrWhiteSpace(userIdClaim) &&
			Guid.TryParse(userIdClaim, out var guidUserId))
		{
			parsedUserId = guidUserId;
		}

		// Set audit fields
		foreach (var entry in auditEntries)
		{
			if (parsedUserId is null)
			{
				if (_loggerFactory.IsEnabled(LogLevel.Warning))
				{
					_loggerFactory.LogWarning(
						"User ID is null while trying to set audit info.");
				}
			}

			switch (entry.State)
			{
				case EntityState.Added:

					entry.Entity.CreatedAt = now;
					break;
			}
		}
	}

	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SaveAuditInfo();
        return await base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        SaveAuditInfo();
        return base.SaveChanges();
    }
}
