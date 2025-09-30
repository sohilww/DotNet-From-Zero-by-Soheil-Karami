using Framework.Domain;

namespace CAS.Domain;
public class Schedule : AggregateRoot<ScheduleId>
{
    public DoctorId DoctorId { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }
    public int Duration { get; private set; } // minutes
    public bool Enable { get; private set; } = true;
    public List<AppointmentPeriod> Periods { get; private set; } = new();

    public Schedule(ScheduleId id, DoctorId doctorId, DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime, int duration)
        : base(id)
    {
        DoctorId = doctorId ?? throw new ArgumentNullException(nameof(doctorId));
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        EndTime = endTime;
        Duration = duration;
    }

    public void GeneratePeriods()
    {
        if (Duration <= 0)
            throw new ArgumentOutOfRangeException(nameof(Duration));

        Periods.Clear();

        var currentStart = StartTime;
        var slotLength = TimeSpan.FromMinutes(Duration);

        while (currentStart + slotLength <= EndTime)
        {
            var currentEnd = currentStart + slotLength;
            Periods.Add(new AppointmentPeriod(AppointmentPeriodId.Generate(), Id, currentStart, currentEnd));
            currentStart = currentEnd;
        }
    }

    public void Disable() => Enable = false;
    public void EnablePeriod() => Enable = true;
}
