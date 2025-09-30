using Framework.Domain;

namespace CAS.Domain;

public class AppointmentId(Guid id) : Id<Guid>(id)
{
    public static AppointmentId Generate()
    {
        return Generate(Guid.NewGuid());
    }

    public static AppointmentId Generate(Guid guid)
    {
        return new AppointmentId(guid);
    }
}


