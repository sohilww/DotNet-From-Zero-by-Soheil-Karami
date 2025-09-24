namespace CAS.Application.Contract
{
    public class GetDoctorDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Speciality { get; set; }
        public string NationalCode { get; set; }
        public List<ScheduleDto> Schedules { get; set; } = new();
    }

    public class ScheduleDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
