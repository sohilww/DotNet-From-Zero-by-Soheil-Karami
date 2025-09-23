namespace CAS.Domain;

public class ClinicHoliday
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }

    public ClinicHoliday(Guid id, DateTime date, string description)
    {
        Id = id;
        Date = date;
        Description = description;
    }
}

