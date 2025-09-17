namespace CAS.Domain.Abstractions.ValueObjects;
public abstract class ValueObjectBase<T> : IValueObject where T : ValueObjectBase<T>
{
    public abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
        => obj is not null &&
           obj is T valueObject &&
           obj.GetType() == GetType() &&
           GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());

    public static bool operator ==(ValueObjectBase<T> left, ValueObjectBase<T> right)
        => left.Equals(right);

    public static bool operator !=(ValueObjectBase<T> left, ValueObjectBase<T> right)
        => !left.Equals(right);

    public override int GetHashCode()
        => GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
}

