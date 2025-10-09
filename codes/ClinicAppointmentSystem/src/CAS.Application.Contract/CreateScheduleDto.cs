namespace CAS.Application.Contract;

public class CreateScheduleDto
{
    public Guid DoctorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int SessionDuration { get; set; }
    public int RestDuration { get; set; }
    public List<DayScheduleDto> DaySchedules { get; set; }
}


public class DayScheduleDto
{
    public DayOfWeek WorkDay { get; set; }
    public List<WorkingHoursDto> Hours { get; set; }
}

public class WorkingHoursDto
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

