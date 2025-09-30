namespace CAS.Domain.Repositories;

public interface IAppointmentRepository
{
    Task<AppointmentId> Create(Appointment appointment, CancellationToken cancellationToken);
    Task<Appointment?> GetById(AppointmentId id, CancellationToken cancellationToken);
    Task<bool> ExistsForDoctorAt(DoctorId doctorId, DateTime date, AppointmentPeriodId periodId, CancellationToken cancellationToken);
}


