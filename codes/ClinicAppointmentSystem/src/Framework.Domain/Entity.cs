namespace Framework.Domain;

public abstract class Entity<TKey>
{
    protected Entity()
    {

    }
    protected Entity(TKey id)
    {
        Id = id;
        CreatingDateTime = DateTime.Now;
    }
    public TKey Id { get; protected set; }


    public override bool Equals(object obj)
    {
        if (obj is not Entity<TKey> entity)
        {
            return false;
        }
        return entity.Id.Equals(this.Id);
    }
    public bool Deleted { get; protected set; } = false;

    //todo: Technical Debt
    //Todo: it's not good pattern for safe delete
    public void Delete()
    {
        Deleted = true;
    }
    public DateTime CreatingDateTime { get; private set; }
}