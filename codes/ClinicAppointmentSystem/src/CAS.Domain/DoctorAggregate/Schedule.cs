using Framework.Domain;

namespace CAS.Domain.DoctorAggregate;

public class Schedule : ValueObject
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int SessionDuration { get; set; }
    public int RestDuration { get; set; }
    public List<DaySchedule> DaySchedules { get; set; }
}

