namespace CAS.Domain.Abstractions.Entities;

public abstract class AggregateRootBase<TId> : EntityBase<TId>
    where TId : notnull
{

    protected AggregateRootBase(TId id) : base(id)
    {

    }
}
