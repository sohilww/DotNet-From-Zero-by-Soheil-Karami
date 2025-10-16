using CAS.Domain.DoctorAggregate;

namespace CAS.Domain.TestHelpers;

public static class ScheduleFactoryTest
{
    public static Schedule Create(
        DateTime startDate,
        DateTime endDate,
        int sessionDurationInMinutes = 30,
        int restDuration = 10,
        params (DayOfWeek WorkDay, string StartTime, string EndTime)[] workDays)
    {
    
        workDays ??= [(DayOfWeek.Saturday, "09:00", "14:00")];

        var daySchedules = workDays.Select(w => new DaySchedule
        {
            WorkDay = w.WorkDay,
            Hours = [new WorkingHours { StartTime = TimeSpan.Parse(w.StartTime), EndTime = TimeSpan.Parse(w.EndTime) }]
        }).ToList();

        return new Schedule
        {
            StartDate = startDate,
            EndDate = endDate,
            SessionDuration = sessionDurationInMinutes,
            RestDuration = restDuration,
            DaySchedules = daySchedules
        };
    }

    public static Schedule CreateDefault(DateTime startDate, DateTime endDate) =>
        Create(startDate, endDate);
}
