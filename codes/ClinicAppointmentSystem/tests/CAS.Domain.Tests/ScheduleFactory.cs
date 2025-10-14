using CAS.Domain.DoctorAggregate;

namespace CAS.Domain.Tests
{
    public record ScheduleParams(
        DateTime StartDate,
        DateTime EndDate,
        int SessionDuration,
        int RestDuration,
        TimeSpan StartTime,
        TimeSpan EndTime,
        DayOfWeek WorkDay = DayOfWeek.Saturday);

    public static class ScheduleFactory
    {
        public static Schedule Create(ScheduleParams vars)
        {
            return new Schedule
            {
                StartDate = vars.StartDate,
                EndDate = vars.EndDate,
                SessionDuration = vars.SessionDuration,
                RestDuration = vars.RestDuration,
                DaySchedules = new List<DaySchedule>
                {
                    new DaySchedule
                    {
                        WorkDay = vars.WorkDay,
                        Hours = new List<WorkingHours>
                        {
                            new WorkingHours
                            {
                                StartTime = vars.StartTime,
                                EndTime = vars.EndTime
                            }
                        }
                    }
                }
            };
        }

        public static Schedule CreateDefault(DateTime startDate, DateTime endDate)
        {
            var defaults = new ScheduleParams(
                StartDate: startDate,
                EndDate: endDate,
                SessionDuration: 30,
                RestDuration: 10,
                StartTime: TimeSpan.Parse("09:00"),
                EndTime: TimeSpan.Parse("14:00"),
                WorkDay: DayOfWeek.Saturday);

            return Create(defaults);
        }
    }
}
