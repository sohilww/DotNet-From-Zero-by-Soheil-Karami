namespace CAS.Domain;
public class Schedule
{
    public Guid Id { get; private set; }
    public Guid DoctorId { get; private set; }
    public DayOfWeek DayOfWeek { get; init; }
    public TimeSpan StartTime { get; init; }
    public TimeSpan EndTime { get; init; }
    public DateTime Date { get; init; }
    public int Duration { get; private set; }
    public bool Enable { get; private set; } = true;
    public List<AppointmentPeriod> Periods { get; private set; } = new();

    public Schedule(Guid doctorId, DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime, int duration)
    {
        Id = Guid.NewGuid();
        DoctorId = doctorId;
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        EndTime = endTime;
        Duration = duration;
    }

 

    public void GeneratePeriods()
    {
    }

    public void Disable() => Enable = false;
    public void EnablePeriod() => Enable = true;
}
