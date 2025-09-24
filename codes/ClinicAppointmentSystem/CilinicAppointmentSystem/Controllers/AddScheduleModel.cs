using CAS.Application.Contract;

namespace CilinicAppointmentSystem.Models
{
    public class AddScheduleModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }


        public AddScheduleDto MapToDto()
        {
            return new AddScheduleDto()
            {
                DayOfWeek = DayOfWeek,
                StartTime = StartTime,
                EndTime = EndTime
            };
        }
    }
}