namespace CAS.Domain.Repositories;

public interface IDoctorVacationRepository
{
    Task<bool> IsDoctorOnVacation(DoctorId doctorId, DateTime date, CancellationToken cancellationToken);
}


