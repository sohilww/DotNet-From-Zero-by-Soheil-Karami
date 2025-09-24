 namespace CAS.Domain;

public class DoctorSchedule
{
    public DayOfWeek DayOfWeek { get; }
    public TimeRange TimeRange { get; }
 

    public DoctorSchedule(DayOfWeek dayOfWeek , TimeRange timeRange)
    {

        TimeRange = timeRange ?? throw new ArgumentNullException(nameof(timeRange));
        DayOfWeek = DayOfWeek;
    }

}
