using Framework.Domain;

namespace CAS.Domain;

public class ClinicHoliday : Entity<ClinicHolidayId>
{
    public DateTime Date { get; private set; }
    public string Description { get; private set; }

    public ClinicHoliday(ClinicHolidayId id, DateTime date, string description)
        : base(id)
    {
        Date = date;
        Description = description;
    }
}