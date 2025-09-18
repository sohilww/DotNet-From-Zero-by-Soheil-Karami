namespace CAS.Domain.Entities;

public class Doctor(string name, string lastname, string expertise, List<Schedule> schedules)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; } = name;
    public string Lastname { get; } = lastname;
    public string Expertise { get; } = expertise;
    public List<Schedule> Schedules { get; } = schedules;
}