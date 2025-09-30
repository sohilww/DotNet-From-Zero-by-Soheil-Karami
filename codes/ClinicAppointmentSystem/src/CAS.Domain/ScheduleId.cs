using Framework.Domain;

namespace CAS.Domain;

public class ScheduleId(Guid id) : Id<Guid>(id)
{
    public static ScheduleId Generate()
    {
        return Generate(Guid.NewGuid());
    }

    public static ScheduleId Generate(Guid guid)
    {
        return new ScheduleId(guid);
    }
}


