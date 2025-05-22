namespace Domain.Common;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; } = default!;

    private readonly List<DomainEvent> _domainEvents = new();
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected Entity() { }

    protected Entity(TId id) => Id = id;

    protected void AddDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public void ClearDomainEvents() => _domainEvents.Clear();

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other)
            return false;

        return Id!.Equals(other.Id);
    }

    public override int GetHashCode() => Id!.GetHashCode();
}
