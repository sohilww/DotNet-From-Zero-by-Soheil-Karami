using Framework.Domain;

namespace CAS.Domain;

public class ClinicHolidayId(Guid id) : Id<Guid>(id)
{
    public static ClinicHolidayId Generate()
    {
        return Generate(Guid.NewGuid());
    }

    public static ClinicHolidayId Generate(Guid guid)
    {
        return new ClinicHolidayId(guid);
    }
}


