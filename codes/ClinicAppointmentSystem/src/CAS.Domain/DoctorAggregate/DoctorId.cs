using Framework.Domain;

namespace CAS.Domain.DoctorAggregate;

public class DoctorId(Guid id) : Id<Guid>(id)
{
    public static DoctorId Generate()
    {
        return Generate(Guid.NewGuid());
    }
    public static DoctorId Generate(Guid guid)
    {
        return new DoctorId(guid);
    }
}