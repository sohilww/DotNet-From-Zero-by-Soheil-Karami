using CAS.Domain.SlotAggregate;
using Framework.Core;
using Framework.Domain;

namespace CAS.Domain.DoctorAggregate;

public class Doctor : AggregateRoot<DoctorId>
{
    private readonly List<Schedule> _schedules;
    public string Name { get; private set; }
    public string Lastname { get; private set; }
    public string Speciality { get; private set; }
    public string NationalityCode { get; private set; }
    public string MedicalCouncilNumber { get; private set; }
    public Gender Gender { get; private set; }
    public ContactInfo ContactInfo { get; private set; }

    public IReadOnlyList<Schedule> Schedules => _schedules.AsReadOnly();

    public Doctor(DoctorId id, string name, string lastname,
        string expertise, string nationalityCode, string medicalCouncilNumber, Gender gender, ContactInfo contactInfo)
        : base(id)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));

        if (name.Length < 2)
            throw new ArgumentNullException(nameof(name));


        if (string.IsNullOrEmpty(lastname))
            throw new ArgumentNullException(nameof(lastname));

        if (!NationalityCodeValidator.IsValid(nationalityCode))
            throw new ArgumentNullException(nameof(nationalityCode));


        Name = name;
        Lastname = lastname;
        Speciality = expertise ?? throw new ArgumentNullException(nameof(expertise));
        NationalityCode = nationalityCode ?? throw new ArgumentNullException(nameof(NationalityCode));
        MedicalCouncilNumber = medicalCouncilNumber;
        Gender = gender;
        ContactInfo = contactInfo;


        _schedules = new List<Schedule>();
    }

    public void CreateSchedule(Schedule schedule)
    {
        if (Schedules.Any(s => s.StartDate == schedule.StartDate ||
                               s.EndDate == schedule.EndDate))
            throw new ArgumentException();


        _schedules.Add(schedule);
    }
    

    public List<Slot> GenerateSlots(DateTime startDate, DateTime endDate)
    {
        var schedule=_schedules.FirstOrDefault(a=>a.StartDate==startDate &&a.EndDate==endDate);

        return null;
    }
}