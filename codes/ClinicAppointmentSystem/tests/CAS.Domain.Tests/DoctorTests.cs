using CAS.Domain.Entities;

namespace CAS.Domain.Tests;

public class DoctorTests

{
    [Fact]
    public void should_build_doctor_properly()
    {
      
        List<Schedule> days = new List<Schedule>
        {
            new Schedule()
            {
                Day = DayOfWeek.Thursday, 
                Date = new DateTime(2022, 2, 15, 19, 9, 58),
                StartTime = new TimeSpan(19, 0, 0),
                EndTime = new TimeSpan(19, 15, 0)
             },
            new Schedule()
            {
            Day = DayOfWeek.Thursday,
            Date = new DateTime(2022, 2, 15, 19, 9, 58),
            StartTime = new TimeSpan(19, 15, 0),
            EndTime = new TimeSpan(19, 30, 0)
        },
            
            new Schedule()
            {
                Day = DayOfWeek.Thursday, 
                Date = new DateTime(2022, 2, 15, 19, 9, 58),
                StartTime = new TimeSpan(19, 30, 0),
                EndTime = new TimeSpan(19, 45, 0)
            },
        };
        var doc = new Doctor("Samaneh", "Yousefi", "dentic", days);

        //fluent Assertioan

    }
}