using CAS.Domain.Models;

namespace CAS.Domain;

public class Doctor
{
    public Guid Id { get; }
    public string Name { get; }
    public string Lastname { get; }
    public string Expertise { get; }
    public string CodeMeli { get; set; }
    //public IReadOnlyList<int> WorkingDays { get; }

    // یک به چند
    public List<Schedule> Schedules { get; private set; } = new();
    public List<Appointment> Appointments { get; private set; } = new();
    public List<DoctorActiveDays> DoctorActiveDays { get; private set; } = new();
    public List<DoctorVacation> Vacations { get; private set; } = new();

    public Doctor(string name, string lastname, string expertise, string codeMeli
        //, List<int> workingDays
        )
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
        Expertise = expertise ?? throw new ArgumentNullException(nameof(expertise));
        CodeMeli = codeMeli ?? throw new ArgumentNullException(nameof(CodeMeli));   
        //WorkingDays = workingDays?.AsReadOnly() ?? throw new ArgumentNullException(nameof(workingDays));
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

