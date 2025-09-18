namespace CAS.Domain.Tests;

public class DoctorTests

{
    [Fact]
    public void should_build_doctor_properly()
    {

        List<int> days = new List<int> { 0, 1, 3 };
        var doc = new Doctor("Samaneh","Yousefi","dentic",days);
        
        
        //fluent Assertioan

    }
}