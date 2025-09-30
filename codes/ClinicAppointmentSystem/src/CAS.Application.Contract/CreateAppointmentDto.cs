namespace CAS.Application.Contract;

public class CreateAppointmentDto
{
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public DateTime Date { get; set; }
    public Guid PeriodId { get; set; }
}


