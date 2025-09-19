namespace CAS.Domain;

public class Doctor
{
    private readonly List<DoctorSchedule> _doctorSchedules = [];
    public Guid Id { get; }
    public string Name { get; }
    public string Lastname { get; }
    public string Expertise { get; }
    public string CodeMeli { get; set; }
    public IReadOnlyList<DoctorSchedule> Schedules  => _doctorSchedules.AsReadOnly();

    public Doctor(string name, string lastname, string expertise, string codeMeli)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
        Expertise = expertise ?? throw new ArgumentNullException(nameof(expertise));
        CodeMeli = codeMeli ?? throw new ArgumentNullException(nameof(CodeMeli)); 
    }
   public void AddSchedoule(AddScheduleParameters parameters) 
    {
        var timeRange = new TimeRange(parameters.startTime, parameters.endTime);
        var doctorSchedoule = new DoctorSchedule(parameters.daysOfWeek, timeRange);

        _doctorSchedules.Add(doctorSchedoule);
    }
}

public record AddScheduleParameters(DayOfWeek daysOfWeek, TimeOnly startTime, TimeOnly endTime);
