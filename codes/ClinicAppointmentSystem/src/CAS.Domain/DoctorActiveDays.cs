using Framework.Domain;

namespace CAS.Domain;

//بازه های زمانی فعال هر دکتر برای رزرو در سیستم
public class DoctorActiveDays : Entity<DoctorActiveDaysId>
{
    public DoctorId DoctorId { get; private set; }
    public DateTime ActivityStartDate { get; private set; }
    public DateTime ActivityEndDate { get; private set; }

    public DoctorActiveDays(DoctorActiveDaysId id, DoctorId doctorId, DateTime start, DateTime end)
        : base(id)
    {
        DoctorId = doctorId ?? throw new ArgumentNullException(nameof(doctorId));
        ActivityStartDate = start;
        ActivityEndDate = end;
    }
}
