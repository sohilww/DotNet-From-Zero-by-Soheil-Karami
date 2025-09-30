using Framework.Domain;

namespace CAS.Domain;

public class DoctorActiveDaysId(Guid id) : Id<Guid>(id)
{
    public static DoctorActiveDaysId Generate()
    {
        return Generate(Guid.NewGuid());
    }

    public static DoctorActiveDaysId Generate(Guid guid)
    {
        return new DoctorActiveDaysId(guid);
    }
}


