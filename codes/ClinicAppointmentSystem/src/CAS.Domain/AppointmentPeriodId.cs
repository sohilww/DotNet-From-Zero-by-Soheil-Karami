using Framework.Domain;

namespace CAS.Domain;

public class AppointmentPeriodId(Guid id) : Id<Guid>(id)
{
    public static AppointmentPeriodId Generate()
    {
        return Generate(Guid.NewGuid());
    }

    public static AppointmentPeriodId Generate(Guid guid)
    {
        return new AppointmentPeriodId(guid);
    }
}


