namespace CAS.Domain;

public class Doctor
{
    public Guid Id { get; }
    public string Name { get; }
    public string Lastname { get; }
    public string Expertise { get; }
    public IReadOnlyList<int> WorkingDays { get; }

    public Doctor(string name, string lastname, string expertise, List<int> workingDays)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
        Expertise = expertise ?? throw new ArgumentNullException(nameof(expertise));
        WorkingDays = workingDays?.AsReadOnly() ?? throw new ArgumentNullException(nameof(workingDays));
    }
}

