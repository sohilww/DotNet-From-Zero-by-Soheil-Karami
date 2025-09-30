using Framework.Domain;

namespace CAS.Domain;

public class PatientId(Guid id) : Id<Guid>(id)
{
    public static PatientId Generate()
    {
        return Generate(Guid.NewGuid());
    }

    public static PatientId Generate(Guid guid)
    {
        return new PatientId(guid);
    }
}


