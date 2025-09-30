using Framework.Domain;

namespace CAS.Domain;

public class DoctorVacationId(Guid id) : Id<Guid>(id)
{
    public static DoctorVacationId Generate()
    {
        return Generate(Guid.NewGuid());
    }

    public static DoctorVacationId Generate(Guid guid)
    {
        return new DoctorVacationId(guid);
    }
}


