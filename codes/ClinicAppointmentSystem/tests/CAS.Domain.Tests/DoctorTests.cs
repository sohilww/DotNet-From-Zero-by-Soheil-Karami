using CAS.Domain.DoctorAggregate;
using CAS.Domain.TestHelpers;
using FluentAssertions;

namespace CAS.Domain.Tests;

public class DoctorTests

{
    private DoctorTestBuilder _builder;

    public DoctorTests()
    {
        _builder = new DoctorTestBuilder();
    }

    [Fact]
    public void should_build_doctor_properly()
    {
        const string name = "Samaneh";
        const string lastname = "Yousefi";
        const string speciality = "dentic";
        const string nationalCode = "3001011017";
        const string medicalCouncilNumber = "123456";
        Gender gender = Gender.Female;
        var contactInfo = new ContactInfo()
        {
            Address = "somewhere",
            MobileNumber = "0912134567",
            PhoneNumber = "02183333"
        };

        var doc =
            _builder.WithName(name)
                .WithLastname(lastname)
                .WithSpeciality(speciality)
                .WithNationalCode(nationalCode)
                .Build();


        doc.Name.Should().Be(name);
        doc.Lastname.Should().Be(lastname);
        doc.NationalityCode.Should().Be(nationalCode);
        doc.Speciality.Should().Be(speciality);
        doc.MedicalCouncilNumber.Should().Be(medicalCouncilNumber);
        doc.Gender.Should().Be(gender);
        doc.ContactInfo.Should().Be(contactInfo);
    }

    [Theory]
    [InlineData("")]
    [InlineData("y")]
    public void should_throw_exception_when_name_is_wrong(string wrongName)
    {
        _builder.WithName(wrongName);

        Action act = () => _builder.Build();

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void should_throw_exception_when_lastname_is_wrong()
    {
        _builder.WithLastname("");

        Action act = () => _builder.Build();

        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("salam")]
    [InlineData("001")]
    [InlineData("00132434")]
    public void should_throw_exception_when_nationalCode_is_wrong(string wrongNationalCode)
    {
        Action act = () => _builder.WithNationalCode(wrongNationalCode).Build();

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void doctor_with_same_id_should_be_equal()
    {
        var id = DoctorId.Generate();
        var firstDoctor = _builder.WithId(id).WithName("FirstDoctor").Build();
        var secondDoctor = _builder.WithId(id).WithName("SecondDoctor").Build();

        firstDoctor.Should().Be(secondDoctor);
    }

    [Fact]
    public void create_a_schedule_for_a_doctor()
    {
        var doctor = new DoctorTestBuilder().Build();
        var schedule = new Schedule();

        doctor.CreateSchedule(schedule);

        doctor.Schedules.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public void should_throw_an_exception_when_schedule_already_exists()
    {
        //state verfication
        //behavior verification
        
        var startDate=DateTime.Now;
        var endDate=startDate.AddDays(30);
        
        var doctor = CreateADoctorWithSchedule(startDate, endDate);

        var alradyCreatedSchedule = CreateSchedule(startDate, endDate);
        
       Action act= ()=>doctor.CreateSchedule(alradyCreatedSchedule);
       
       act.Should().Throw<ArgumentException>();
        
    }

    [Fact]
    public void should_generate_slots_for_specific_schedule()
    {
        var startDate = DateTime.Parse("2025-10-09");
        var endDate = startDate.AddDays(1);

        var schedule = ScheduleFactoryTest.Create(
            startDate,
            endDate,
            sessionDurationInMinutes: 60,
            restDuration: 0,
            (DayOfWeek.Saturday, "10:00", "12:00")
        );
        var doctor = CreateADoctorWithSchedule(schedule);


        var slots = doctor.GenerateSlots(startDate, endDate);

        slots.Count.Should().Be(2);
        slots.First().StartDateTime.Should().Be(DateTime.Parse("2025-10-09 10:00:00"));
        slots.First().EndDateTime.Should().Be(DateTime.Parse("2025-10-09 11:00:00"));
    }

    private Doctor CreateADoctorWithSchedule(DateTime startDate, DateTime endDate)
    {
        var firstSchedule = CreateSchedule(startDate, endDate);
       return CreateADoctorWithSchedule(firstSchedule);
    }
    
    private Doctor CreateADoctorWithSchedule(Schedule schedule)
    {
        var doctor = new DoctorTestBuilder()
            .WithSchedule(schedule)
            .Build();
        return doctor;
    }

    private Schedule CreateSchedule(DateTime startDate, DateTime endDate)
    {
        return ScheduleFactoryTest.Create(startDate, endDate);
    }
}