namespace CAS.Domain.Abstractions.Entities;

public abstract class AggregateRootBase<TId> : EntityBase<TId>, IAggregateRoot
    where TId : notnull
{

    protected AggregateRootBase(TId id) : base(id)
    {

    }
}
