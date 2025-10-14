using CAS.Domain.DoctorAggregate;
using CAS.Domain.Tests;

namespace CAS.Domain.TestHelpers;

public class DoctorTestBuilder
{
    private DoctorId _id;
    private string _name;
    private string _lastname;
    private string _speciality;
    private string _nationalityCode;
    private Schedule _schedule;

    public DoctorTestBuilder()
    {
        _name = "Samaneh";
        _lastname = "Yousefi";
        _speciality = "general";
        _nationalityCode = "3001011017";
        _schedule = CreateSchedule();
    }
    private Schedule CreateSchedule()
    {
        return ScheduleFactory.CreateDefault(DateTime.Now, DateTime.Now.AddMonths(1));
    }
    public DoctorTestBuilder WithId(Guid id)
    {
        _id = DoctorId.Generate(id);
        return this;
    }
    public DoctorTestBuilder WithId(DoctorId id)
    {
        _id = id;
        return this;
    }
    public DoctorTestBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    public DoctorTestBuilder WithLastname(string lastname)
    {
        _lastname = lastname;
        return this;
    }
    public DoctorTestBuilder WithSpeciality(string speciality)
    {
       _speciality = speciality;
       return this;
    }
    public DoctorTestBuilder WithNationalCode(string nationalityCode)
    {
        _nationalityCode = nationalityCode;
        return this;
    }
    public DoctorTestBuilder WithSchedule(Schedule schedule)
    {
        _schedule = schedule;
        return this;

    }
    public Doctor Build()
    {
        const string medicalCouncilNumber = "123456";
        Gender gender = Gender.Female;
        var contactInfo = new ContactInfo()
        {
            Address = "somewhere",
            MobileNumber = "0912134567",
            PhoneNumber = "02183333"
        };
        
         var doctor= new Doctor(_id, _name, _lastname,
            _speciality, _nationalityCode,
            medicalCouncilNumber, gender, contactInfo);
         
         doctor.CreateSchedule(_schedule);
         
         return doctor;
    }


  
}