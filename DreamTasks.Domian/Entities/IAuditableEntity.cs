namespace Domain.Entities;

/// <summary>
/// Defines properties for tracking the creation, modification, and deletion metadata of an entity for auditing
/// purposes.
/// </summary>
/// <remarks>Implement this interface to enable audit logging of entity lifecycle events, such as when an entity
/// is created, updated, or deleted. The properties provide information about the user responsible for each action and
/// the corresponding timestamps. This interface is typically used in applications that require change tracking or
/// compliance with audit requirements.</remarks>
public interface IAuditableEntity : IBaseEntity
{
    public DateTime CreatedAt { get; set; }
}
