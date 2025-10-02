using CAS.Application.Contract;

namespace CilinicAppointmentSystem.Models;


public class CreateScheduleModel
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int SessionDuration { get; set; }
    public int RestDuration { get; set; }
    public List<DayScheduleModel> DaySchedules { get; set; }

    public CreateScheduleDto MapToDto(Guid id)
    {
        return new CreateScheduleDto()
        {
            DoctorId = id,
            SessionDuration = SessionDuration,
            RestDuration = RestDuration,
            StartDate = StartDate,
            EndDate = EndDate,
            DaySchedules = DaySchedules.Select(a => new DayScheduleDto()
            {
                WorkDay = a.WorkDay,
                Hours = a.Hours.Select(b=> new WorkingHoursDto()
                {
                    EndTime = b.EndTime,
                    StartTime = b.StartTime,
                }).ToList()
            }).ToList()
        };
    }
}


public class DayScheduleModel
{
    public DayOfWeek WorkDay { get; set; }
    public List<WorkingHoursModel> Hours { get; set; }
}

public class WorkingHoursModel
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}


// public class AnotherWayOfImplementingDaySchedule
// {
//     public DayOfWeek WorkDay { get; set; }
//     public TimeSpan StartTime { get; set; }
//     public TimeSpan EndTime { get; set; }
// }
