namespace Domain.Entities;

/// <summary>
/// Represents an entity with a unique identifier.
/// </summary>
public interface IBaseEntity
{
    public Guid Id { get; set; }
}
