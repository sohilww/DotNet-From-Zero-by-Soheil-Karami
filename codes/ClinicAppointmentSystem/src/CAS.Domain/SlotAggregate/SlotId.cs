using Framework.Domain;

namespace CAS.Domain.SlotAggregate;

public class SlotId(Guid id) : Id<Guid>(id)
{
    public static SlotId Generate()
    {
        return Generate(Guid.NewGuid());
    }
    public static SlotId Generate(Guid guid)
    {
        return new SlotId(guid);
    }
}