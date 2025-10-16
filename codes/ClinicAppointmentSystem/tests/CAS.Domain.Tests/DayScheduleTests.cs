using CAS.Domain.DoctorAggregate;
using FluentAssertions;

namespace CAS.Domain.Tests;

public class DayScheduleTests
{
    //Saturday => 10:00 => 11:00
    //Saturday => 11:00 => 12:00
    //Saturday => 12:00 => 13:00
    //Saturday => 13:00 => 14:00
    [Fact]
    public void should_generate_hours_for_specific_day()
    {
        var daySchedule = new DaySchedule()
        {
            WorkDay = DayOfWeek.Saturday,
            Hours = new List<WorkingHours>()
            {
                new WorkingHours()
                {
                    StartTime = TimeSpan.Parse("10:00"),
                    EndTime = TimeSpan.Parse("14:00"),
                }
            }
        };


        int sessionDuration=60;
        var result= daySchedule.Generate(sessionDuration, 0);


        result.Count.Should().Be(4);
        result.First().WorkDay.Should().Be(DayOfWeek.Saturday);
        result.First().StartTime.Should().Be(TimeSpan.Parse("10:00"));
        result.First().EndTime.Should().Be(TimeSpan.Parse("11:00"));
        
        
        result.Last().WorkDay.Should().Be(DayOfWeek.Saturday);
        result.Last().StartTime.Should().Be(TimeSpan.Parse("13:00"));
        result.Last().EndTime.Should().Be(TimeSpan.Parse("14:00"));

    }
    [Fact]
    public void should_generate_working_hours_for_day_with_tenis_time()
    {
        var daySchedule = new DaySchedule()
        {
            WorkDay = DayOfWeek.Saturday,
            Hours = new List<WorkingHours>()
            {
                new WorkingHours()
                {
                    StartTime = TimeSpan.Parse("10:00"),
                    EndTime = TimeSpan.Parse("14:00"),
                },
                new WorkingHours()
                {
                    StartTime = TimeSpan.Parse("17:00"),
                    EndTime = TimeSpan.Parse("20:00"),
                }
            }
        };

        int sessionDuration = 60;
        var result = daySchedule.Generate(sessionDuration, 0);


        result.Count.Should().Be(7);
        result.First().WorkDay.Should().Be(DayOfWeek.Saturday);
        result.First().StartTime.Should().Be(TimeSpan.Parse("10:00"));
        result.First().EndTime.Should().Be(TimeSpan.Parse("11:00"));
        
        
        result.Last().WorkDay.Should().Be(DayOfWeek.Saturday);
        result.Last().StartTime.Should().Be(TimeSpan.Parse("19:00"));
        result.Last().EndTime.Should().Be(TimeSpan.Parse("20:00"));

    }

    //10:00 => 12:00 sessionDuration 45 => 10:00 => 10:45 / 10:45 => 11:30 / should not create 11:30 => 12:15  
    [Fact] 

    public void should_generate_sessions_with_extra_hours()
    {
        var daySchedule = new DaySchedule()
        {
            WorkDay = DayOfWeek.Saturday,
            Hours = new List<WorkingHours>()
            {
                new WorkingHours()
                {
                    StartTime = TimeSpan.Parse("10:00"),
                    EndTime = TimeSpan.Parse("12:00"),
                }
            }
        };

        int sessionDuration = 45;
        int restDuration = 0;
        var result = daySchedule.Generate(sessionDuration, restDuration);


        result.Count.Should().Be(2);

        result.First().StartTime.Should().Be(TimeSpan.Parse("10:00"));
        result.First().EndTime.Should().Be(TimeSpan.Parse("10:45"));

        result.Last().StartTime.Should().Be(TimeSpan.Parse("10:45"));
        result.Last().EndTime.Should().Be(TimeSpan.Parse("11:30"));
    }

 

    //10:00 => 12:00 sessionDuration 45 , restDuration = 15 => 10:00 => 10:45 / 11:00 => 12:00
    [Fact]
    public void should_generate_hours_with_session_and_rest_duration()
    {
        var daySchedule = new DaySchedule()
        {
            WorkDay = DayOfWeek.Saturday,
            Hours = new List<WorkingHours>()
            {
                new WorkingHours()
                {
                    StartTime = TimeSpan.Parse("10:00"),
                    EndTime = TimeSpan.Parse("12:00"),
                }
            }
        };

        int sessionDuration = 45;
        int restDuration = 15;
        var result = daySchedule.Generate(sessionDuration, restDuration);


        result.Count.Should().Be(2);

        result.First().StartTime.Should().Be(TimeSpan.Parse("10:00"));
        result.First().EndTime.Should().Be(TimeSpan.Parse("10:45"));

        result.Last().StartTime.Should().Be(TimeSpan.Parse("11:00"));
        result.Last().EndTime.Should().Be(TimeSpan.Parse("11:45"));
    }
   
    //10:00 => 12:00 sessionDuration 30 , restDuration = 15 => 10:00 => 10:30 / 10:45 => 11:30 / should not create 11:45 => 12:15
    
}