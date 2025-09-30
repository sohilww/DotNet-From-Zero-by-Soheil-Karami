using Framework.Domain;

namespace CAS.Domain;

public class AppointmentPeriod : Entity<AppointmentPeriodId>
{
    public ScheduleId ScheduleId { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }

    public AppointmentPeriod(AppointmentPeriodId id, ScheduleId scheduleId, TimeSpan startTime, TimeSpan endTime)
        : base(id)
    {
        ScheduleId = scheduleId ?? throw new ArgumentNullException(nameof(scheduleId));
        StartTime = startTime;
        EndTime = endTime;
    }
}
