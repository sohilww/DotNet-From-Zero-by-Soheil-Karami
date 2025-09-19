using FluentAssertions;

namespace CAS.Domain.Tests;

public class DoctorTests

{
    [Fact]
    public void should_build_doctor_properly()
    {

        var doctor = new Doctor("Samaneh","Yousefi","dentic","3001011017");
        
        
        //fluent Assertioan

    }

    [Fact]
    public void should_add_schedoule_to_doctor_schedules()
    {

        var doctor = new Doctor("Samaneh", "Yousefi", "dentic", "3001011017");
        var addSchedouleParameters = new AddScheduleParameters(DayOfWeek.Sunday, new TimeOnly(12, 00), new TimeOnly(16, 00));

        doctor.AddSchedoule(addSchedouleParameters);

        doctor.Schedules.Should().HaveCount(1);
    }

    [Fact]
    public void should_not_add_invalid_schedoule_to_doctor_schedules()
    {

        var doctor = new Doctor("Samaneh", "Yousefi", "dentic", "3001011017");
        var addSchedouleParameters = new AddScheduleParameters(DayOfWeek.Sunday, new TimeOnly(16, 00), new TimeOnly(12, 00));

        Action act = () => doctor.AddSchedoule(addSchedouleParameters);

        act.Should().Throw<ArgumentException>().WithMessage("End time must be after start time.");
    }

    //TODO Add schedule with overlap schedule (Faezeh)

}