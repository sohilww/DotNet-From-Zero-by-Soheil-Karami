namespace CAS.Domain;

public class AppointmentPeriod
{
    public Guid PeriodId { get; private set; }
    public Guid ScheduleId { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }

    public AppointmentPeriod(Guid periodId, Guid scheduleId, TimeSpan startTime, TimeSpan endTime)
    {
        PeriodId = periodId;
        ScheduleId = scheduleId;
        StartTime = startTime;
        EndTime = endTime;
    }

}
