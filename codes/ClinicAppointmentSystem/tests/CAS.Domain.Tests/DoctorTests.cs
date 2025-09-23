namespace CAS.Domain.Tests;

public class DoctorTests

{
    [Fact]
    public void should_build_doctor_properly()
    {
        Guid doctorId = new Guid();

        List<Schedule> days = new List<Schedule>
        {
            new Schedule(doctorId, DayOfWeek.Thursday, new TimeSpan(19,15,0), new TimeSpan(19,30,0), 15)
            {
                Date = new DateTime(2022, 2, 15, 19, 9, 58)
            },
            new Schedule(doctorId, DayOfWeek.Thursday, new TimeSpan(19,30,0), new TimeSpan(19,45,0), 15)
            {
                Date = new DateTime(2022, 2, 15, 19, 9, 58)
            },

            new Schedule(doctorId, DayOfWeek.Thursday, new TimeSpan(19,45,0), new TimeSpan(20,0,0), 15)
            {
                Date = new DateTime(2022, 2, 15, 19, 9, 58)
            },
        }; 
        
        var doc = new Doctor("Samaneh","Yousefi","dentic","3001011017", "3001011017",new List<Schedule>());
        
        
        //fluent Assertioan

    }
}