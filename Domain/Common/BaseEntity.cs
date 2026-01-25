namespace Domain.Common;

/// <summary>
/// Base class for all domain entities.
/// Provides identity handling and equality logic based on domain identity,
/// not object reference or database identifiers.
/// </summary>
public abstract class BaseEntity 
{
    /// <summary>
    /// Initializes a new entity instance and assigns a domain-level unique identifier.
    /// This identifier is independent of persistence concerns and exists
    /// from the moment the entity is created.
    /// </summary>
    protected BaseEntity()
    {
        Uuid = Guid.NewGuid();
    }

    /// <summary>
    /// Database identifier.
    /// This value is assigned by the persistence layer and should not be
    /// used for domain equality comparisons.
    /// </summary>
    public int Id { get; protected set; }

    /// <summary>
    /// Domain identity of the entity.
    /// Used to determine equality between entities regardless of their state.
    /// </summary>
    public Guid Uuid { get; protected set; }

    /// <summary>
    /// Determines whether the specified object is equal to the current entity.
    /// Equality is based on domain identity (Uuid), not reference or mutable properties.
    /// </summary>
    public override bool Equals(object? obj)
    {
        // Object must be a BaseEntity
        if (obj is not BaseEntity other)
            return false;

        // Same reference implies equality 
        if (ReferenceEquals(this, other))
            return true;

        // Entities of different types are never equal
        if (GetType() != other.GetType())
            return false;

        // Domain equality is determined by identity
        return Uuid == other.Uuid;
    }

    /// <summary>
    /// Returns a hash code based on the domain identity.
    /// This ensures correct behavior in hash-based collections
    /// such as Dictionary and HashSet.
    /// </summary>
    public override int GetHashCode()
    {
        return Uuid.GetHashCode();
    }

    /// <summary>
    /// Equality operator overload.
    /// Delegates equality comparison to the Equals method
    /// and safely handles null references.
    /// </summary>
    public static bool operator ==(BaseEntity? a, BaseEntity? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is not null)
            return a?.Equals(b) ?? false;

        return false;
    }

    /// <summary>
    /// Inequality operator overload.
    /// Logical negation of the equality operator.
    /// </summary>
    public static bool operator !=(BaseEntity? a, BaseEntity? b)
        => !(a == b);

}
