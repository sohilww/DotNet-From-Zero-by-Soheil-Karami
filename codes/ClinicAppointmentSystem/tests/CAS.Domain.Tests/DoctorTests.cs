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
        var id=DoctorId.Generate();
        var firstDoctor = _builder.WithId(id).WithName("FirstDoctor").Build();
        var secondDoctor = _builder.WithId(id).WithName("SecondDoctor").Build();
        
        firstDoctor.Should().Be(secondDoctor);
        
    }
    
}