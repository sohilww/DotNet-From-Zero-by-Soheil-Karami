namespace CAS.Domain;

public class Doctor
{
    public Guid Id { get; }
    public string Name { get; }
    public string Lastname { get; }
    public string Expertise { get; }
    public string NationalCode { get; set; }
    public string MedicalRecordNumber { get; set; }

    public List<Schedule> Schedule { get; }

    // یک به چند
    public List<Schedule> Schedules { get; private set; } = new();
    public List<Appointment> Appointments { get; private set; } = new();
    public List<DoctorActiveDays> DoctorActiveDays { get; private set; } = new();
    public List<DoctorVacation> Vacations { get; private set; } = new();

    public Doctor(string name, string lastname, string expertise, string nationalCode, string medicalRecordNumber
        , List<Schedule> schedule
        )
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
        Expertise = expertise ?? throw new ArgumentNullException(nameof(expertise));
        NationalCode = nationalCode ?? throw new ArgumentNullException(nameof(NationalCode));
        MedicalRecordNumber = medicalRecordNumber ?? throw new ArgumentNullException(nameof(MedicalRecordNumber));
        Schedule = schedule?.ToList() ?? new List<Schedule>();
    }


    // متدهای Domain برای مدیریت Aggregate
    public void AddSchedule(Schedule schedule)
    {
        Schedules.Add(schedule);
    }

    public void AddVacation(DoctorVacation vacation)
    {
        Vacations.Add(vacation);
    }

    public void AddActiveDay(DoctorActiveDays day)
    {
        DoctorActiveDays.Add(day);
    }

}

