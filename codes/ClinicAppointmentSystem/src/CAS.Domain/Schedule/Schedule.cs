using System.Runtime.InteropServices.JavaScript;

namespace CAS.Domain.Schedule;

public class Schedule
{
    public DayOfWeek Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public DateTime Date { get; set; }
}