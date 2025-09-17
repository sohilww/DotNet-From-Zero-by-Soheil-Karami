namespace CAS.Domain.Models;
public class Doctor
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Expertise { get; private set; }
    public string ContactInfo { get; private set; }

    // یک به چند
    public List<Schedule> Schedules { get; private set; } = new();
    public List<Appointment> Appointments { get; private set; } = new();
    public List<DoctorActiveDays> DoctorActiveDays { get; private set; } = new();
    public List<DoctorVacation> Vacations { get; private set; } = new();

    public Doctor(Guid id, string firstName, string lastName, string expertise, string contactInfo)
    {
        Id = id;
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Expertise = expertise;
        ContactInfo = contactInfo;
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
