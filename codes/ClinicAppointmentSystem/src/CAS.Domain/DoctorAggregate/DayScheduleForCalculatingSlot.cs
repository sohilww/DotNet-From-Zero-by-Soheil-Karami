namespace CAS.Domain.DoctorAggregate;

public class DayScheduleForCalculatingSlot
{
    public DayOfWeek WorkDay { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}