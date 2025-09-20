 namespace CAS.Domain;

public class TimeRange
{
    public TimeOnly StartTime { get; }
    public TimeOnly EndTime { get; }


    public TimeRange(TimeOnly startTime, TimeOnly endTime)
    {
        if (endTime <= startTime)
            throw new ArgumentException("End time must be after start time.");

        StartTime = startTime;
        EndTime = endTime;
    
    }
    public bool HasOverlapp(TimeRange timeRange)
    {
        return StartTime < timeRange.StartTime & EndTime > timeRange.EndTime;
    }

}
