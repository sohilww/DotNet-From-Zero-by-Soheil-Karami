using FluentAssertions;

namespace CAS.Domain.Tests;

public class ScheduleTests
{
    [Fact]
    public void generate_periods_should_fill_slots_between_start_and_end()
    {
        var schedule = new Schedule(ScheduleId.Generate(), DoctorId.Generate(), DayOfWeek.Monday,
            new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0), 20);

        schedule.GeneratePeriods();

        schedule.Periods.Should().HaveCount(3);
        schedule.Periods[0].StartTime.Should().Be(new TimeSpan(9, 0, 0));
        schedule.Periods[0].EndTime.Should().Be(new TimeSpan(9, 20, 0));
        schedule.Periods[^1].StartTime.Should().Be(new TimeSpan(9, 40, 0));
        schedule.Periods[^1].EndTime.Should().Be(new TimeSpan(10, 0, 0));
    }
}


