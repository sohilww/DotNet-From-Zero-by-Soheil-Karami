namespace CAS.Domain.Repositories;

public interface IDoctorActiveDaysRepository
{
    Task<bool> IsWithinActiveDays(DoctorId doctorId, DateTime date, CancellationToken cancellationToken);
}


