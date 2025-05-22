namespace Domain.Common;

public abstract class Aggregate<TId> : Entity<TId>
{
    protected Aggregate() : base() { }
    protected Aggregate(TId id) : base(id) { }
}
