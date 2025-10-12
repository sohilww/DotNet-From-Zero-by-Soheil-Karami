using Framework.Core;

namespace Framework.Domain;

public abstract class ValueObject
{
    public override int GetHashCode()
    {
        return HashCodeBuilder.ReflectionHashCode(this);
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        return EqualsBuilder.ReflectionEquals(obj, this);
    }
}