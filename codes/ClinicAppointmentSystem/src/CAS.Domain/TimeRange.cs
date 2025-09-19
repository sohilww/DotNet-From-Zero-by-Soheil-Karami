 namespace CAS.Domain;

public class TimeRange
{
    public TimeOnly StartTime { get; }
    public TimeOnly EndTime { get; }

    public TimeRange(TimeOnly startTime, TimeOnly endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
        Validations();
    }

    private void Validations()
    {
        StartTimeShouldAfterEndTimeValidation();
    }

    private void StartTimeShouldAfterEndTimeValidation()
    {
        if (EndTime <= StartTime)
            throw new ArgumentException("End time must be after start time.");
    }

    public bool OverlapsWith(TimeRange other)
    {
        return StartTime < other.EndTime && EndTime > other.StartTime;
    }
}
